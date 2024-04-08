using Npgsql;
using StemaxGeoCode.Data;

namespace StemaxGeoCode.Repository.Addresses
{
    internal class DbObjectRepository : iObjectsRepository
    {
        private NpgsqlConnection dbConnection;

        public DbObjectRepository(string username, string password, int port = 5432, string host = "127.0.0.1", string database = "mgs")
        {
            var dbConnectionStrBuilder = new NpgsqlConnectionStringBuilder();
            dbConnectionStrBuilder.Host = host;
            dbConnectionStrBuilder.Database = database;
            dbConnectionStrBuilder.Username = username;
            dbConnectionStrBuilder.Password = password;
            dbConnectionStrBuilder.Port = 5432;

            dbConnection = new NpgsqlConnection(dbConnectionStrBuilder.ToString());
        }

        async public Task<List<iObjectData>> loadAllObjects()
        {
            var objList = new List<iObjectData>();
            await dbConnection.OpenAsync();

            var batch = new NpgsqlBatch(dbConnection)
            {
                BatchCommands =
                {
                    new NpgsqlBatchCommand(@"
                        UPDATE 
	                        object
                        SET
	                        settings = CONCAT(settings, 'Lat=0','Lon=0')
                        WHERE
	                        SUBSTRING(settings, 'Lat=(([[:digit:]]*)(\.?)([[:digit:]]*))') is NULL"),
                    new NpgsqlBatchCommand(@"
                        SELECT 
	                        o.object_id,
                            o.name,
	                        SUBSTRING(o.settings, 'Address=([[:alpha:][:digit:][:punct:][:blank:]]*)') as address,
                            SUBSTRING(o.settings, 'Lon=(([[:digit:]]*)(\.?)([[:digit:]]*))') as Longitude,                        
                            SUBSTRING(o.settings, 'Lat=(([[:digit:]]*)(\.?)([[:digit:]]*))') as Latitude	                        
                        FROM
	                        object o
                        JOIN 
	                        objectgroup g ON o.group_id = g.group_id
                        WHERE
	                        g.name LIKE '%ЮЛ%' OR g.name LIKE '%ФЛ%'
                        ORDER BY address")
                }
            };

            var reader = await batch.ExecuteReaderAsync();

            while (reader.Read())
            {
                double lon = double.Parse(reader.GetString(3).Replace('.', ','));
                double lat = double.Parse(reader.GetString(4).Replace('.', ','));
                string finalAddress = reader.GetString(2).Trim();
                iObjectData obj = new ObjectData(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), new Coordinate(lon, lat));
                objList.Add(obj);
            }

            await dbConnection.CloseAsync();
            return objList;
        }

        public void saveAllObjects(List<iObjectData> objects)
        {
            throw new NotImplementedException();
        }

        async public void saveObject(iObjectData obj)
        {
            await dbConnection.OpenAsync();
            var dbCommand = new NpgsqlCommand(@"
                UPDATE 
	                object
                SET
	                settings = REGEXP_REPLACE(
		                REGEXP_REPLACE(
			                settings,
			                'Lat=(([[:digit:]]*)(\.?)([[:digit:]]*))',
			                'Lat=(@objlat)'
		                ),
		                'Lon=(([[:digit:]]*)(\.?)([[:digit:]]*))',
		                'Lon=(@objlon)'
	                )
                WHERE
	                object_id = (@objid)")
            {
                Parameters =
                {
                    new("objlat", obj.Coordinate.Latitude),
                    new("objlon", obj.Coordinate.Longitude),
                    new("objid", obj.Id)
                }
            };
            await dbConnection.CloseAsync();
        }
    }
}

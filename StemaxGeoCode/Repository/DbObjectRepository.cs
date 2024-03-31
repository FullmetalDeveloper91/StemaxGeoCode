using Npgsql;
using StemaxGeoCode.Data;
using StemaxGeoCode.Data.GeoCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace StemaxGeoCode.Repository
{
    internal class DbObjectRepository : iObjectsRepository
    {       
        private NpgsqlConnection? dbConnection = null;

        public DbObjectRepository()
        {
            var dbConnectionStrBuilder = new NpgsqlConnectionStringBuilder();
            dbConnectionStrBuilder.Host = "127.0.0.1";
            dbConnectionStrBuilder.Database = "mgs";
            dbConnectionStrBuilder.Username = "postgres";
            dbConnectionStrBuilder.Password = "root";
            dbConnectionStrBuilder.Port = 5432;

            dbConnection = new NpgsqlConnection(dbConnectionStrBuilder.ToString());
        }

        async public Task<List<iObjectData>> loadAllObjects()
        {
            var objList = new List<iObjectData>();
            await dbConnection?.OpenAsync();
            var command = dbConnection!.CreateCommand();
            command.CommandText = @"
                SELECT object.object_id, object.name, object.settings FROM object
                JOIN objectgroup ON object.group_id = objectgroup.group_id
                WHERE objectgroup.name LIKE '%ЮЛ%' OR objectgroup.name LIKE '%ФЛ%'
            ";

            var reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                iObjectData obj = new ObjectData(reader.GetInt32(0), reader.GetString(1));
                objList.Add(obj);
            }

            return objList;
        }

        public void saveAllObjects()
        {
            throw new NotImplementedException();
        }

        public void saveObject(int id)
        {
            throw new NotImplementedException();
        }       
    }
}

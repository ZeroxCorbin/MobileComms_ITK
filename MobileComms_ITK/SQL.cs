using MobileComms_ITK.JSON.Types;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileComms_ITK
{
    public class SQL
    {
        public enum QueryType
        {
            SELECT,
            UPDATE,
            INSERT
        }

        public class View
        {
            public string Name { get; set; }
            public Dictionary<QueryType, Type> QueryTypes { get; set; }
        }
        public List<View> Views { get; } = new List<View>()
        {
            { new View { Name = "data_store_item_view", QueryTypes = new Dictionary<QueryType, Type>() { { QueryType.SELECT, typeof(DataStoreItem) } } } },
            { new View { Name = "data_store_value_view", QueryTypes = new Dictionary<QueryType, Type>() { { QueryType.SELECT, typeof(DataStoreValue) } } } },
            { new View { Name = "goal_view", QueryTypes = new Dictionary<QueryType, Type>() { { QueryType.SELECT, typeof(Goal) } } } },

            { new View { Name = "job_view", QueryTypes = new Dictionary<QueryType, Type>() { { QueryType.SELECT, typeof(Job) } } } },
            { new View { Name = "job_segment_view", QueryTypes = new Dictionary<QueryType, Type>() { { QueryType.SELECT, typeof(JobSegment) } } } },
            { new View { Name = "job_history_view", QueryTypes = new Dictionary<QueryType, Type>() { { QueryType.SELECT, typeof(JobHistory) } } } },
            { new View { Name = "job_segment_history_view", QueryTypes = new Dictionary<QueryType, Type>() { { QueryType.SELECT, typeof(JobSegmentHistory) } } } },

            { new View { Name = "job_request_view", QueryTypes = new Dictionary<QueryType, Type>() { { QueryType.INSERT, typeof(JobRequest_POST) } } } },
            { new View { Name = "job_request_detail_view", QueryTypes = new Dictionary<QueryType, Type>() { { QueryType.INSERT, typeof(JobRequestDetail_POST) } } } },
            { new View { Name = "job_cancel_view", QueryTypes = new Dictionary<QueryType, Type>() { { QueryType.INSERT, typeof(JobCancel_POST) } } } },
            { new View { Name = "job_segment_modify_view", QueryTypes = new Dictionary<QueryType, Type>() { { QueryType.INSERT, typeof(JobSegmentModify_POST) } } } },

            { new View { Name = "pickup_view", QueryTypes = new Dictionary<QueryType, Type>() { { QueryType.INSERT, typeof(Pickup_POST) } } } },
            { new View { Name = "dropoff_view", QueryTypes = new Dictionary<QueryType, Type>() { { QueryType.INSERT, typeof(Dropoff_POST) } } } },
            { new View { Name = "pickup_dropoff_view", QueryTypes = new Dictionary<QueryType, Type>() { { QueryType.INSERT, typeof(PickupDropoff_POST) } } } },

            { new View { Name = "robot_view", QueryTypes = new Dictionary<QueryType, Type>() { { QueryType.SELECT, typeof(Robot) } } } },
            { new View { Name = "robot_fault_view", QueryTypes = new Dictionary<QueryType, Type>() { { QueryType.SELECT, typeof(RobotFault) } } } },
            { new View { Name = "robot_history_view", QueryTypes = new Dictionary<QueryType, Type>() { { QueryType.SELECT, typeof(RobotHistory) } } } },
            { new View { Name = "robot_fault_history_view", QueryTypes = new Dictionary<QueryType, Type>() { { QueryType.SELECT, typeof(RobotFaultHistory) } } } },

            { new View { Name = "subscription_config_view", QueryTypes = new Dictionary<QueryType, Type>() { { QueryType.SELECT, typeof(SubscriptionConfig) }, { QueryType.UPDATE, typeof(SubscriptionConfig_PUT) } } } },
        };

        //public Dictionary<string, Dictionary<QueryType, string>> Views { get; } = new Dictionary<string, Dictionary<QueryType, string>>()
        //{
        //    { "data_store_item_view", new Dictionary<QueryType, string>() { { QueryType.SELECT, "DataStoreItem" } } },
        //    { "data_store_value_view", new Dictionary<QueryType, string>() { { QueryType.SELECT, "DataStoreValue" } } },
        //    { "goal_view", new Dictionary<QueryType, string>() { { QueryType.SELECT, "Goal" } } },

        //    { "job_view", new Dictionary<QueryType, string>() { { QueryType.SELECT, "Job" } } },
        //    { "job_segment_view", new Dictionary<QueryType, string>() { { QueryType.SELECT, "JobSegment" } } },
        //    { "job_history_view", new Dictionary<QueryType, string>() { { QueryType.SELECT, "JobHistory" } } },
        //    { "job_segment_history_view", new Dictionary<QueryType, string>() { { QueryType.SELECT, "JobSegmentHistory" } } },

        //    { "job_request_view", new Dictionary<QueryType, string>() { { QueryType.INSERT, "JobRequest_POST" } } },
        //    { "job_request_detail_view", new Dictionary<QueryType, string>() { { QueryType.INSERT, "JobRequestDetail_POST" } } },
        //    { "job_cancel_view", new Dictionary<QueryType, string>() { { QueryType.INSERT, "JobCancel_POST" } } },
        //    { "job_segment_modify_view", new Dictionary<QueryType, string>() { { QueryType.INSERT, "JobSegmentModify_POST" } } },

        //    { "pickup_view", new Dictionary<QueryType, string>() { { QueryType.INSERT, "Pickup_POST" } } },
        //    { "dropoff_view", new Dictionary<QueryType, string>() { { QueryType.INSERT, "Dropoff_POST" } } },
        //    { "pickup_dropoff_view", new Dictionary<QueryType, string>() { { QueryType.INSERT, "PickupDropoff_POST" } } },

        //    { "robot_view", new Dictionary<QueryType, string>() { { QueryType.SELECT, "Robot" } } },
        //    { "robot_fault_view", new Dictionary<QueryType, string>() { { QueryType.SELECT, "RobotFault" } } },
        //    { "robot_history_view", new Dictionary<QueryType, string>() { { QueryType.SELECT, "RobotHistory" } } },
        //    { "robot_fault_history_view", new Dictionary<QueryType, string>() { { QueryType.SELECT, "RobotFaultHistory" } } },

        //    { "subscription_config_view", new Dictionary<QueryType, string>() { { QueryType.SELECT, "SubscriptionConfig" }, { QueryType.UPDATE, "SubscriptionConfig_PUT" } } },
        //};

        public string UserName => "toolkitadmin";
        public string ConnectionString(string host, string password) => $"Host={host};Username={UserName};Password={password};Database=IntegrationDB;TrustServerCertificate=true;SSLMode=Require";
        public NpgsqlConnection Connection { get; private set; }

        public bool IsException { get; private set; }
        public Exception SQLException { get; private set; }

        private void Reset()
        {
            SQLException = null;
            IsException = false;
        }
        public bool Connect(string host, string password)
        {
            Reset();

            Connection = new NpgsqlConnection(ConnectionString(host, password));

            try
            {
                Connection.Open();
                return true;
            }
            catch(Exception ex)
            {
                SQLException = ex;
                IsException = true;
                return false;
            }
        }
        public void Close()
        {
            Reset();

            Connection?.Close();
        }
        public DataSet Select(string query)
        {
            Reset();

            try
            {
                if(Connection != null && Connection.State == ConnectionState.Open) 
                {
                    using var cmd = new NpgsqlCommand(query, Connection);
                    DataSet ds = new DataSet();
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.Fill(ds);
                    return ds;
                }
                return new DataSet();
            }
            catch(PostgresException ex)
            {
                SQLException = ex;
                IsException = true;
                return new DataSet();
            }
        }
        public string GetScheme(string view)
        {
            Reset();

            try
            {
                if(Connection != null && Connection.State == ConnectionState.Open)
                {
                    string query = $"SELECT \"definition\" FROM \"pg_views\" WHERE \"viewname\" = '{view}' AND \"schemaname\" = 'public'";

                    using var cmd = new NpgsqlCommand(query, Connection);
                    //DataSet ds = new DataSet();
                    //NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    StringBuilder sb = new StringBuilder();
                    using var reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        object[] objs = new object[reader.FieldCount];
                        reader.GetValues(objs);
                        foreach(object obj in objs)
                        {
                            sb.Append($"{obj} ");
                        }
                        sb.Append($"\r\n");
                    }


                    return sb.ToString();
                    //da.Fill(ds);
                    //return ds;
                }
                return "";
            }
            catch(PostgresException ex)
            {
                SQLException = ex;
                IsException = true;
                return "";
            }
        }
        public int Insert(string query)
        {
            Reset();

            try
            {
                if(Connection != null && Connection.State == ConnectionState.Open)
                {
                    using var cmd = new NpgsqlCommand(query, Connection);

                    //cmd.Parameters.AddWithValue("p", "some_value");
                    return cmd.ExecuteNonQuery();
                }
                return -1;
            }
            catch(PostgresException ex)
            {
                SQLException = ex;
                IsException = true;
                return -1;
            }
        }

        public int Update(string query)
        {
            Reset();

            try
            {
                if(Connection != null && Connection.State == ConnectionState.Open)
                {
                    using var cmd = new NpgsqlCommand(query, Connection);

                    //cmd.Parameters.AddWithValue("p", "some_value");
                    return cmd.ExecuteNonQuery();
                }
                return -1;
            }
            catch(PostgresException ex)
            {
                SQLException = ex;
                IsException = true;
                return -1;
            }
        }

    }
}

﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.IntegrationToolkit
{
    public class SQL
    {
        public enum QueryTypes
        {
            SELECT,
            UPDATE,
            INSERT
        }

        public Dictionary<string, Dictionary<QueryTypes, string>> Views { get; } = new Dictionary<string, Dictionary<QueryTypes, string>>()
        {
            { "data_store_item_view", new Dictionary<QueryTypes, string>() { { QueryTypes.SELECT, "DataStoreItem_GET" } } },
            { "data_store_value_view", new Dictionary<QueryTypes, string>() { { QueryTypes.SELECT, "DataStoreValue_GET" } } },
            { "goal_view", new Dictionary<QueryTypes, string>() { { QueryTypes.SELECT, "" } } },

            { "job_view", new Dictionary<QueryTypes, string>() { { QueryTypes.SELECT, "" } } },
            { "job_segment_view", new Dictionary<QueryTypes, string>() { { QueryTypes.SELECT, "JobSegmentMonitoring_GET" } } },
            { "job_history_view", new Dictionary<QueryTypes, string>() { { QueryTypes.SELECT, "" } } },
            { "job_segment_history_view", new Dictionary<QueryTypes, string>() { { QueryTypes.SELECT, "" } } },

            { "job_request_view", new Dictionary<QueryTypes, string>() { { QueryTypes.INSERT, "JobRequest_POST" } } },
            { "job_request_detail_view", new Dictionary<QueryTypes, string>() { { QueryTypes.INSERT, "" } } },
            { "job_cancel_view", new Dictionary<QueryTypes, string>() { { QueryTypes.INSERT, "JobCancel_POST" } } },
            { "job_segment_modify_view", new Dictionary<QueryTypes, string>() { { QueryTypes.INSERT, "JobSegmentModify_POST" } } },

            { "pickup_view", new Dictionary<QueryTypes, string>() { { QueryTypes.INSERT, "Pickup_POST" } } },
            { "dropoff_view", new Dictionary<QueryTypes, string>() { { QueryTypes.INSERT, "Dropoff_POST" } } },
            { "pickup_dropoff_view", new Dictionary<QueryTypes, string>() { { QueryTypes.INSERT, "PickupDropoff_POST" } } },

            { "robot_view", new Dictionary<QueryTypes, string>() { { QueryTypes.SELECT, "Robot_GET" } } },
            { "robot_fault_view", new Dictionary<QueryTypes, string>() { { QueryTypes.SELECT, "RobotFault_GET" } } },
            { "robot_history_view", new Dictionary<QueryTypes, string>() { { QueryTypes.SELECT, "Robot_GET" } } },
            { "robot_fault_history_view", new Dictionary<QueryTypes, string>() { { QueryTypes.SELECT, "RobotFault_GET" } } },

            { "subscription_config_view", new Dictionary<QueryTypes, string>() { { QueryTypes.SELECT, "Subscription_GET" }, { QueryTypes.UPDATE, "Subscription_PUT" } } },
        };

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
        public DataSet GetScheme(string view)
        {
            Reset();

            try
            {
                if(Connection != null && Connection.State == ConnectionState.Open)
                {
                    string query = $"SELECT \"definition\" FROM \"pg_views\" WHERE \"viewname\" = '{view}' AND \"schemaname\" = 'public'";

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
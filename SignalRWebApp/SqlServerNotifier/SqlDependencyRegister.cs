using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SignalRWebApp.SqlServerNotifier
{
    public class SqlDependencyRegister
    {
        public event SqlNotificationEventHandler SqlNotification;

        readonly NotifierEntity notificationEntity;

        internal SqlDependencyRegister(NotifierEntity notificationEntity)
        {
            this.notificationEntity = notificationEntity;
            RegisterForNotifications();
        }
        Dictionary<string, string> DependencyNotification = new Dictionary<string, string>();
        Dictionary<string, string> NotifiersDependency = new Dictionary<string, string>();
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        void RegisterForNotifications()
        {
            using (var sqlConnection = new SqlConnection(notificationEntity.SqlConnectionString))
            using (var sqlCommand = new SqlCommand(notificationEntity.SqlQuery, sqlConnection))
            {
                foreach (var sqlParameter in notificationEntity.SqlParameters)
                    sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Notification = null;
                var sqlDependency = new SqlDependency(sqlCommand);
                sqlDependency.OnChange += OnSqlDependencyChange;
                var id = sqlDependency.Id;
                if (!NotifiersDependency.ContainsKey(notificationEntity.SqlQuery))
                    NotifiersDependency.Add(notificationEntity.SqlQuery, id);
                NotifiersDependency[notificationEntity.SqlQuery] = id;
                if (!DependencyNotification.ContainsKey(id))
                    DependencyNotification.Add(id, notificationEntity.SqlQuery);
                else
                    DependencyNotification[id] = notificationEntity.SqlQuery;
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        void OnSqlDependencyChange(object sender, SqlNotificationEventArgs e)
        {
            //var sqlDep = sender as SqlDependency;
            //var id = sqlDep.Id;
            //if (DependencyNotification.ContainsKey(id))
            //{
            //    sender = DependencyNotification[id];
            //}
            if (SqlNotification != null)
                SqlNotification(sender, e);
            RegisterForNotifications();
        }
    }
}
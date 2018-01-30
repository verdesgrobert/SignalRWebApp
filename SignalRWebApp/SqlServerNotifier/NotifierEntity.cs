﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace SignalRWebApp.SqlServerNotifier
{
    public class NotifierEntity
    {
        ICollection<SqlParameter> sqlParameters = new List<SqlParameter>();

        public String SqlQuery { get; set; }

        public String SqlConnectionString { get; set; }

        public ICollection<SqlParameter> SqlParameters
        {
            get
            {
                return sqlParameters;
            }
            set
            {
                sqlParameters = value;
            }
        }

        public static NotifierEntity FromJson(String value)
        {
            if (String.IsNullOrEmpty(value))
                return null;

            return new JavaScriptSerializer().Deserialize<NotifierEntity>(value);
        }
    }
}
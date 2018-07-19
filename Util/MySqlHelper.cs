using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Util
{
    public class MySqlHelper
    {
        #region Connection
        private string connStr;

        private MySqlConnection conn;
        public MySqlHelper() {
            this.ConnStr = Util.ConfigHelper.GetConnectionStr("connStr");
            this.Conn = new MySqlConnection(this.ConnStr);
        }


        public string ConnStr
        {
            get
            {
                return connStr;
            }

            set
            {
                connStr = value;
            }
        }

        public MySqlConnection Conn
        {
            get
            {
                return conn;
            }

            set
            {
                conn = value;
            }
        }
        public void CloseConn() {
            if (conn != null && conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }
        #endregion

        #region PrepareCommand
        /// <summary>
        /// Command对象执行前预处理
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="conn"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="parms"></param>
        private void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, CommandType cmdType, string cmdText, params MySqlParameter[] parms)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                cmd.CommandType = cmdType;

                if (parms != null)
                {
                    foreach (MySqlParameter parm in parms)
                        cmd.Parameters.Add(parm);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region ExecuteNonQuery
        /// <summary>
        /// 普通SQL语句执行增删改
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="parms">可变参数</param>
        /// <returns>受影响行数</returns>
        public int ExecuteNonQuery(string cmdText, params MySqlParameter[] parms) {
            return ExecuteNonQuery(cmdText, CommandType.Text, parms);
        }
        /// <summary>
        /// 执行增删改
        /// </summary>
        /// <param name="cmdText">命令字符串</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdParams">可变参数</param>
        /// <returns>受影响行数</returns>
        public int ExecuteNonQuery(string cmdText, CommandType cmdType, params MySqlParameter[] cmdParams) {
            int ret = 0;
            using (MySqlConnection conn = this.Conn) {
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    PrepareCommand(cmd, conn, cmdType, cmdText, cmdParams);
                    ret = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally {
                    if (conn != null && conn.State != ConnectionState.Closed) {
                        conn.Close();
                    }                    
                }
            }
            return ret;
        }
        public int ExecuteNonQueryByProc(string cmdText,params MySqlParameter[] parms) {
            return ExecuteNonQuery(cmdText, CommandType.StoredProcedure, parms);
        }
        #endregion

        #region ExecuteReader
        public MySqlDataReader ExecuteReader(string cmdText,params MySqlParameter[] parms) {
            return ExecuteReader(cmdText,CommandType.Text,parms);
        }
        public MySqlDataReader ExecuteReaderByProc(string cmdText, params MySqlParameter[] parms)
        {
            return ExecuteReader(cmdText, CommandType.StoredProcedure, parms);
        }
        public MySqlDataReader ExecuteReader(string cmdText,CommandType cmdType,params MySqlParameter[] parms) {
            MySqlDataReader reader = null;

            //using (MySqlConnection conn = this.Conn) {
 
            //}

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                PrepareCommand(cmd, this.Conn, cmdType, cmdText, parms);
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                this.Conn.Close();
                throw new Exception(ex.Message);
            }

            return reader;
        }
        #endregion

        #region ExecuteDataSet
        public DataSet ExecuteDataSet(string cmdText,params MySqlParameter[] parms) {
            return ExecuteDataSet(cmdText, CommandType.Text, parms);
        }
        public DataSet ExecuteDataSetByProc(string cmdText, params MySqlParameter[] parms)
        {
            return ExecuteDataSet(cmdText, CommandType.StoredProcedure, parms);
        }

        public DataSet ExecuteDataSet(string cmdText,CommandType cmdType,params MySqlParameter[] parms) {
            DataSet dataSet = null;

            using (MySqlConnection conn = this.Conn) {
                MySqlCommand cmd = new MySqlCommand();
                PrepareCommand(cmd, conn, cmdType, cmdText, parms);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                dataSet = new DataSet();
                adapter.Fill(dataSet);
            }
            return dataSet;
        }
        #endregion

        #region [ ExecuteDataTable ]  
        /// <summary>  
        /// 执行SQL语句, 返回DataTable  
        /// </summary>  
        /// <param name="cmdText">命令字符串</param>  
        /// <param name="parms">可变参数</param>  
        /// <returns> DataTable </returns>  
        public DataTable ExecuteDataTable(string cmdText, params MySqlParameter[] parms)
        {
            return ExecuteDataTable(cmdText, CommandType.Text, parms);
        }

        /// <summary>  
        /// 执行存储过程, 返回DataTable  
        /// </summary>  
        /// <param name="cmdText">命令字符串</param>  
        /// <param name="parms">可变参数</param>  
        /// <returns> DataTable </returns>  
        public DataTable ExecuteDataTableByProc(string cmdText, params MySqlParameter[] parms)
        {
            return ExecuteDataTable(cmdText, CommandType.StoredProcedure, parms);
        }

        /// <summary>  
        /// 返回DataTable  
        /// </summary>  
        /// <param name="cmdText">命令字符串</param>  
        /// <param name="cmdType">命令类型</param>  
        /// <param name="parms">可变参数</param>  
        /// <returns> DataTable </returns>  
        public DataTable ExecuteDataTable(string cmdText, CommandType cmdType, params MySqlParameter[] parms)
        {
            DataTable dtResult = null;
            DataSet ds = ExecuteDataSet(cmdText, cmdType, parms);

            if (ds != null && ds.Tables.Count > 0)
            {
                dtResult = ds.Tables[0];
            }
            return dtResult;
        }
        #endregion

        #region [ ExecuteScalar ]  
        /// <summary>  
        /// 普通SQL语句执行ExecuteScalar  
        /// </summary>  
        /// <param name="cmdText">SQL语句</param>  
        /// <param name="parms">可变参数</param>  
        /// <returns>受影响行数</returns>  
        public object ExecuteScalar(string cmdText, params MySqlParameter[] parms)
        {
            return ExecuteScalar(cmdText, CommandType.Text, parms);
        }
        /// <summary>  
        /// 存储过程执行ExecuteScalar  
        /// </summary>  
        /// <param name="cmdText">存储过程</param>  
        /// <param name="parms">可变参数</param>  
        /// <returns>受影响行数</returns>  
        public object ExecuteScalarByProc(string cmdText, params MySqlParameter[] parms)
        {
            return ExecuteScalar(cmdText, CommandType.StoredProcedure, parms);
        }
        /// <summary>  
        /// 执行ExecuteScalar  
        /// </summary>  
        /// <param name="cmdText">命令字符串</param>  
        /// <param name="cmdType">命令类型</param>  
        /// <param name="parms">可变参数</param>  
        /// <returns>受影响行数</returns>  
        public object ExecuteScalar(string cmdText, CommandType cmdType, params MySqlParameter[] parms)
        {
            object result = null;

            using (MySqlConnection conn = this.Conn)
            {
                try
                {
                    MySqlCommand command = new MySqlCommand();
                    PrepareCommand(command, conn, cmdType, cmdText, parms);
                    result = command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (conn != null && conn.State != ConnectionState.Closed)
                        conn.Close();
                }
            }
            return result;
        }
        #endregion

    }
}
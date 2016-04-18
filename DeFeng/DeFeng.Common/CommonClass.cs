using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DeFeng.Model.Global;

namespace DeFeng.Common
{
    public class CommonClass
    {
        /// <summary>
        /// 构建Http Post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postDataStr"></param>
        /// <returns></returns>
        public static string HttpPost(string url, string postDataStr)
        {
            string retString = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                // request.Timeout = 5000;
                request.Method = "POST";
                request.ContentType = "text/plain";
                request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
                Stream myRequestStream = request.GetRequestStream();
                StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
                myStreamWriter.Write(postDataStr);
                myStreamWriter.Close();

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream myResponseStream = response.GetResponseStream();
                    StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                    retString = myStreamReader.ReadToEnd();
                    myStreamReader.Close();
                    myResponseStream.Close();
                }
            }
            catch (Exception ex)
            {

                retString = "-1";
            }
            return retString;
        }
        /// <summary>
        /// 构建Http Get请求
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="postDataStr"></param>
        /// <returns></returns>
        public static string HttpGet(string Url, string postDataStr)
        {
            string retString = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
                // request.Timeout = 5000;
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";
                request.Headers.Add(HttpRequestHeader.CacheControl, "Cache-Control: no-cache");

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream myResponseStream = response.GetResponseStream();
                    StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                    retString = myStreamReader.ReadToEnd();
                    myStreamReader.Close();
                    myResponseStream.Close();
                }
            }
            catch (Exception ex)
            {

                retString = "-1";
            }
            return retString;
        }
        /// <summary>
        /// 写入错误日志
        /// </summary>
        /// <param name="log">日志</param>
        /// <param name="path">存储路径</param>
        //public static void WriteLog(Log log)
        //{
        //    try
        //    {

        //        //var path = string.Format("{0}/{1}/{2}", ConfigurationManager.AppSettings["logSavePath"], logTypeName, log.assemblyName);
        //        var path = GetLogPath(log);
        //        var repository = LogManager.GetRepository();
        //        var appenders = repository.GetAppenders();
        //        var targetApder = appenders.First(p => p.Name == "RollingLogFileAppender") as RollingFileAppender;
        //        targetApder.File = path;
        //        targetApder.ActivateOptions();
        //        ILog ilog = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        //        ilog.Error(log.msg);
        //    }
        //    catch (Exception ex)
        //    {
        //        ILog ilog = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        //        ilog.Error(ex.Message);
        //    }


        /// <summary>
        /// 发送消息到MSMQ
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="msg"></param>
        /// <param name="MSMQName"></param>
        //public static void SendToMSMQ(MSMQ msmq)
        //{
        //    try
        //    {
        //        var par = string.Format("FormatName:Direct=TCP:{0}\\private$\\{1}", msmq.MSMQIP, msmq.MSMQName);
        //        MessageQueue messageQueue = new MessageQueue(par);
        //        Message m = new Message(msmq.msg);
        //        messageQueue.Send(m, DateTime.Now.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        Log log = new Log { assemblyName = GetAssemblyName(), msg = ex.Message + ex.StackTrace, type = Log.LogType.ErrorLog };
        //        Model.Queue.LogQueues.LogQueue.Enqueue(log);//将错误消息写入安全队列
        //        WriteLog(null);
        //    }
        //}


        /// <summary>
        /// 获取本机ip(局域网)
        /// </summary>
        /// <returns></returns>
        public static string GetAddressIP()
        {
            ///获取本地的IP地址
            string AddressIP = string.Empty;
            try
            {
                foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
                {
                    if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                    {
                        AddressIP = _IPAddress.ToString();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return AddressIP;
        }
        /// <summary>
        /// 读取xml文件
        /// </summary>
        /// <param name="path">完整路径</param>
        /// <returns></returns>
        public static XmlDocument LoadXml(string path)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(path);
            }
            catch (Exception ex)
            {

            }
            return doc;
        }

        /// <summary>
        /// 读取需要加载的系统配置项
        /// </summary>
        /// <param name="xmlFilePath"></param>
        /// <returns></returns>
        public static List<string> LoadSysConfigKey(string xmlFilePath)
        {
            List<string> list = new List<string>();
            try
            {
                var sysConfDoc = LoadXml(xmlFilePath);
                var nodes = sysConfDoc.SelectNodes("/root/key");
                for (int i = 0; i < nodes.Count; i++)
                {
                    list.Add(nodes[i].InnerText);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        /// <summary>
        /// 根据根据key读取系统配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetSysConfig(string key)
        {
            var value = "";
            try
            {
                if (GlobalDictionary.SysConfDictionary.ContainsKey(key))
                {
                    value = GlobalDictionary.SysConfDictionary[key];
                }
            }
            catch (Exception ex) { }
            return value;
        }
        /// <summary>
        /// 加载系统配置
        /// </summary>
        /// <param name="needLoadConfigList">需要加载的配置</param>
        /// <returns></returns>
        public static bool LoadSysConfig(List<string> needLoadConfigList)
        {
            var isLoadSuccess = false;//配置是否加载成功
            try
            {
                for (int i = 0; i < needLoadConfigList.Count; i++)
                {
                    var value = ConfigurationManager.AppSettings[needLoadConfigList[i]];
                    GlobalDictionary.SysConfDictionary.Add(needLoadConfigList[i], value);
                }
                isLoadSuccess = true;
            }
            catch (Exception ex)
            {
                isLoadSuccess = false;
            }
            return isLoadSuccess;
        }
        /// <summary>
        /// http转换成string
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public static string HttpRequestConvertToStr(MemoryStream ms)
        {
            var httpResult = "";
            try
            {
                var bytes = ms.GetBuffer();
                System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
                byte[] nBytes = new byte[ms.Length];
                for (int i = 0; i < ms.Length; i++)
                {
                    nBytes[i] = bytes[i];
                }
                httpResult = UTF8.GetString(nBytes);
            }
            catch (Exception ex)
            {

            }
            return httpResult;
        }
    }
}
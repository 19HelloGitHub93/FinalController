using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using ServerWinform.model;

namespace ServerWinform
{
    public class LocalDataModel
    {
        public Dictionary<string, AppItem> commandDic;
        public Dictionary<string, string> deletePath;
    }
    public class LoadData
    {
        private static LoadData _instance;
        public static LoadData Instance
        {
            get
            {
                if(_instance==null)
                    _instance = new LoadData();
                return _instance;
            }
        }

        private LocalDataModel dataModel = new LocalDataModel();
        private string dataPath = Application.StartupPath + "\\data.json";

        public LoadData()
        {
            if (File.Exists(dataPath))
            {
                try
                {
                    string readData = File.ReadAllText(dataPath);
                    LocalDataModel _data = JsonConvert.DeserializeObject<LocalDataModel>(readData);
                    if (_data != null)
                        dataModel = _data;
                }
                catch (Exception e)
                {
                    DialogResult dialogResult = MessageBox.Show(string.Format("配置文件加载出错\r\n文件路径:{0}",dataPath+"\r\n是否重置"),"提示",MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.OK)
                    {
                        File.Delete(dataPath);
                    }
                }
            }
        }
        
        public Dictionary<string, AppItem> getCommandData()
        {
            return dataModel.commandDic;
        }

        public Dictionary<string, string> getDeletepathData()
        {
            return dataModel.deletePath;
        }

        public void SaveData(Dictionary<string, AppItem> commandData)
        {
            dataModel.commandDic = commandData;
            SaveData();
        }
        
        public void SaveData(Dictionary<string, string> deletePathData)
        {
            dataModel.deletePath = deletePathData;
            SaveData();
        }

        private void SaveData()
        {
            string json = JsonConvert.SerializeObject(dataModel);
            if (!File.Exists(dataPath))
            {
                File.CreateText(dataPath).Close();
            }
            
            File.WriteAllText(dataPath,json);
        }
    }
}
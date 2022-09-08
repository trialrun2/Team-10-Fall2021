using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Newtonsoft.Json;

namespace Alarm501_Library
{
    public class FileHandler
    {
        #region Fields
        /// <summary>
        /// The model to save/load to.
        /// </summary>
        private AlarmListM _model;

        /// <summary>
        /// The file name of the file to save/load from.
        /// </summary>
        private string _fileName = "alarms.txt";
        #endregion


        #region Constructors
        /// <summary>
        /// Constructs a new instance of a <see cref="FileHandler"/> class.
        /// </summary>
        /// <param name="m">The model to save/load to.</param>
        public FileHandler(AlarmListM m) => _model = m;
        #endregion


        #region Methods
        /// <summary>
        /// Loads the model's information from a file.
        /// </summary>
        public void LoadFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(_fileName))
                using (JsonTextReader input = new JsonTextReader(sr))
                {
                    JsonSerializerSettings settings = new JsonSerializerSettings() { Formatting = Formatting.Indented };
                    JsonSerializer serializer = JsonSerializer.Create(settings);

                    BindingList<Alarm> alarms = serializer.Deserialize<BindingList<Alarm>>(input);

                    foreach (Alarm alarm in alarms) _model.AddAlarm(alarm);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        /// <summary>
        /// Saves the model's information as a file.
        /// </summary>
        public void SaveFile()
        {
            try
            {
                using (StreamWriter output = new StreamWriter(_fileName))
                {
                    JsonSerializerSettings settings = new JsonSerializerSettings() { Formatting = Formatting.Indented };

                    JsonSerializer serializer = JsonSerializer.Create(settings);
                    serializer.Serialize(output, _model.Alarms);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
        #endregion
    }
}

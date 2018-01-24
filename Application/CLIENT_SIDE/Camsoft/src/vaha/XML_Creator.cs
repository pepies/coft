using System;
using System.Collections.Generic;

namespace Camsoft
{
    public class xmlCreator
    {
        private List<ActualLogData> _list;
        public List<ActualLogData> list
        {
            get { return _list; }
        }
        public xmlCreator()
        {
            _list = new List<ActualLogData>();
        }

        public void add(ActualLogData f)
        {
            _list.Add(f);
        }
        public void stop_record(string id)
        {
            Vtt.listToFile(_list, id);
            ftpController.xml.addToSendBuffer(id, "vtt");
        }
    }
}

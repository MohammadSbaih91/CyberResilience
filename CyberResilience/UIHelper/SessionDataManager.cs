using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CyberResilience.UIHelper
{
    public class SessionDataManager
    {
        private readonly Controller _controller;

        public SessionDataManager(Controller controller)
        {
            _controller = controller;
        }

        public void AddOrUpdate(string key, object value)
        {
            _controller.Session[key] = value;
        }

        public object Get(string key)
        {
            return _controller.Session[key];
        }
    }
}
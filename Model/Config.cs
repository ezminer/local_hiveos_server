using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class Config
    {
        public event EventHandler 新增矿机事件;
        public void 触发新增矿机事件()
        {
            新增矿机事件?.Invoke(this,null);

        }
    }
}

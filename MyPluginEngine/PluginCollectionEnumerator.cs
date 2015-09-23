using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/**
 * author lk 
 * 2014/12/20
 * 插件式gis应用框架的设计与实现
 *  容器迭代器
 * （访问容器中的元素，读取容器中的数据项而不能修改集合中的数据）
 * 
 * */
namespace MyPluginEngine
{
    /// <summary>
    /// 插件容器迭代器
    /// </summary>
    public class PluginCollectionEnumerator : IEnumerator
    {
        /// <summary>
        /// 枚举接口
        /// </summary>
        private IEnumerable _temp;
        /// <summary>
        /// 非泛型迭代接口
        /// </summary>
        private IEnumerator _enumerator;
        public PluginCollectionEnumerator()
        { }
        /// <summary>
        /// 插件容器迭代器构造函数
        /// </summary>
        /// <param name="mappings">插件集合</param>
        public PluginCollectionEnumerator(PluginCollection mappings)
        {
            _temp = (IEnumerable)mappings;
            _enumerator = _temp.GetEnumerator();
        }
        #region IEnumerator 成员
        /// <summary>
        /// 获得集合中的当前元素
        /// </summary>
        public object Current
        {
            get { return _enumerator.Current; }
        }
        /// <summary>
        /// 获取下一个元素
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            return _enumerator.MoveNext();
        }
        /// <summary>
        /// 重新设置集合对象
        /// </summary>
        public void Reset()
        {
            _enumerator.Reset();
        }

        #endregion
    }
}

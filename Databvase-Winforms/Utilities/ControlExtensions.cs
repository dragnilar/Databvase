using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Databvase_Winforms.Utilities
{
    public static class ControlExtensions
    {
        /// <summary>
        /// Extension for creating SAFE data bindings with binding sources.
        /// Source: https://stackoverflow.com/a/12581544
        /// </summary>
        /// <typeparam name="TControl"></typeparam>
        /// <typeparam name="TDataSourceItem"></typeparam>
        /// <param name="control"></param>
        /// <param name="controlProperty"></param>
        /// <param name="dataSource"></param>
        /// <param name="dataSourceProperty"></param>
        /// <returns></returns>
        public static Binding Bind<TControl, TDataSourceItem>
        (this TControl control,
            Expression<Func<TControl, object>> controlProperty,
            object dataSource,
            Expression<Func<TDataSourceItem, object>> dataSourceProperty)
            where TControl : Control
        {
            return control.DataBindings.Add
            (PropertyName.For(controlProperty),
                dataSource,
                PropertyName.For(dataSourceProperty));
        }


        /// <summary>
        /// Extension for creating SAFE data bindings with binding sources, accepts formatting updateMode and DataSourceUpdateMode.
        /// Source: https://stackoverflow.com/a/12581544
        /// </summary>
        /// <typeparam name="TControl"></typeparam>
        /// <typeparam name="TDataSourceItem"></typeparam>
        /// <param name="control"></param>
        /// <param name="controlProperty"></param>
        /// <param name="dataSource"></param>
        /// <param name="dataSourceProperty"></param>
        /// <param name="formattingEnabled"></param>
        /// <param name="updateMode"></param>
        /// <returns></returns>
        public static Binding Bind<TControl, TDataSourceItem>
        (this TControl control,
            Expression<Func<TControl, object>> controlProperty,
            object dataSource,
            Expression<Func<TDataSourceItem, object>> dataSourceProperty,
            bool formattingEnabled,
            DataSourceUpdateMode updateMode)
            where TControl : Control
        {
            return control.DataBindings.Add
            (PropertyName.For(controlProperty),
                dataSource,
                PropertyName.For(dataSourceProperty),
                formattingEnabled,
                updateMode);

        }
    }


    public static class PropertyName
    {
        public static string For<T>(Expression<Func<T, object>> property)
        {
            var member = property.Body as MemberExpression;
            if (null == member)
            {
                var unary = property.Body as UnaryExpression;
                if (null != unary) member = unary.Operand as MemberExpression;
            }
            return null != member ? member.Member.Name : string.Empty;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArquiteturaModelo.Apresentacao.WF.Model.Base
{
    public static class BaseModelExtensions
    {
        /// <summary>
        /// Binds the specified view model.
        /// </summary>
        /// <typeparam name="TModel">The type of the view model.</typeparam>
        /// <typeparam name="TControl">The type of the control.</typeparam>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <param name="viewModel">The view model.</param>
        /// <param name="control">The control.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="dataMember">The data member.</param>
        /// <returns></returns>
        public static Binding Bind<TModel, TControl, T1, T2>(
            this TModel viewModel,
            TControl control,
            Expression<Func<TControl, T1>> propertyName,
            Expression<Func<TModel, T2>> dataMember,
            bool formattingEnabled = false,
            DataSourceUpdateMode updateMode = DataSourceUpdateMode.OnPropertyChanged,
            bool autoValidate = true)
            where TModel : BaseModel
            where TControl : IBindableComponent
        {

            viewModel.AttachedControls.Add(GetPropertyName(dataMember), control);

            if (autoValidate)
            {
                (control as Control).Validating += (s, e) => { viewModel.Validate(); };
                
            }

            return control.DataBindings.Add(
                propertyName.GetPropertyName(),
                viewModel,
                dataMember.GetPropertyName(),
                formattingEnabled,
                updateMode);
        }

        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        private static string GetPropertyName<T1, T2>(this Expression<Func<T1, T2>> action)
        {
            var expression = (MemberExpression)action.Body;
            var propertyName = expression.Member.Name;
            return propertyName;
        }
    }
}

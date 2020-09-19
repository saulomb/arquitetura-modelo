namespace ArquiteturaModelo.Apresentacao.WF.Model.Base
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class BaseModel : NotifyPropertyChangedObject,   IDataErrorInfo 
    {
        private Dictionary<string, IBindableComponent> attachedControls = new Dictionary<string, IBindableComponent>();
        private Dictionary<string, string> messages = new Dictionary<string, string>();
        private bool isValidating = false;
        private string error;


        [Browsable(false)]
        public string this[string property]
        {
            get
            {
                var propertyDescriptor = TypeDescriptor.GetProperties(this)[property];
                if (propertyDescriptor == null)
                    return string.Empty;

                var results = new List<ValidationResult>();
                var result = Validator.TryValidateProperty(
                                          propertyDescriptor.GetValue(this),
                                          new ValidationContext(this, null, null)
                                          { MemberName = property },
                                          results);
                if (!result)
                    return results.First().ErrorMessage;
                return string.Empty;
            }
        }

        //[Browsable(false)]
        //public string Error
        //{
        //    get
        //    {
        //        var results = new List<ValidationResult>();
        //        var result = Validator.TryValidateObject(this,
        //            new ValidationContext(this, null, null), results, true);
        //        if (!result)
        //            //return string.Join("\n", results.Select(x => x.ErrorMessage));
        //            return string.Join(Environment.NewLine, results.Select(x => x.ErrorMessage));
        //        else
        //            return null;
        //    }
        //}


        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// </summary>
        /// <returns>An error message indicating what is wrong with this object. The default is an empty string ("").</returns>
        public string Error
        {
            get
            {
                return error;
            }
        }


        public Dictionary<string, string> Validate()
        {
            var results = new List<ValidationResult>();
            var result = Validator.TryValidateObject(this,
                new ValidationContext(this, null, null), results, true);

            var cancelArgs = new CancelEventArgs(false);
            this.OnValidating(this, cancelArgs);

            if (!cancelArgs.Cancel && !isValidating)
            {
                messages.Clear();
                if (results != null && results.Any())
                {
                    results.ToList().ForEach(r =>
                    {
                        if (!messages.ContainsKey(r.MemberNames.First()))
                        {
                            messages.Add(r.MemberNames.First(), r.ErrorMessage);
                        }
                        else
                        {
                            messages[r.MemberNames.First()] += Environment.NewLine + r.ErrorMessage;
                        }
                    });
                }
            }

            this.error = string.Join(Environment.NewLine, messages.Select(m => m.Value));

            if (!cancelArgs.Cancel)
            {
                this.OnValidated(this, EventArgs.Empty);
            }

            return messages;
            //this.error = string.Join(Environment.NewLine, messages.Select(m => m.Value));
            //return messages;
        }

    public Dictionary<string, string> Messages
    {
        get
        {
            return this.messages;
        }
    }



    public Dictionary<string, IBindableComponent> AttachedControls
        {
            get { return this.attachedControls; }
        }




        /// <summary>
        /// Occurs when [validated].
        /// </summary>
        public event EventHandler Validated;

        /// <summary>
        /// Occurs when [validating].
        /// </summary>
        public event EventHandler<CancelEventArgs> Validating;

        /// <summary>
        /// Called when [validated].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnValidated(object sender, EventArgs e)
        {
            if (this.Validated != null)
            {
                this.Validated(sender, e);
            }
            this.isValidating = false;
        }

        /// <summary>
        /// Called when [validating].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        protected virtual void OnValidating(object sender, CancelEventArgs e)
        {
            if (this.Validating != null)
            {
                this.Validating(sender, e);
            }
        }





    }
}


public interface IDataErrorInfo
{
    string this[string columnName] { get; }
    string Error { get; }
}

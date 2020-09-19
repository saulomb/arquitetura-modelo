using ArquiteturaModelo.Apresentacao.WF.Model.Base;
using ArquiteturaModelo.Apresentacao.WF.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArquiteturaModelo.Apresentacao.WF.Base
{

   // [TypeDescriptionProvider(typeof(AbstractDescriptionProvider<FormBase, System.Windows.Forms.Form>))]
    public partial class FormBase<TModel> : Form where TModel : BaseModel
    {
        private ErrorProvider errorProvider;

        public FormBase(ViewModel<TModel> viewModel)
        {
            this.errorProvider = new ErrorProvider(this);
            this.ViewModel = viewModel;
            //this.ViewModelValidated();

           // this.ViewModel.Model.Validated += new EventHandler(Model_Validated);
        }

        public ViewModel<TModel> ViewModel { get; set; }


        protected override void OnLoad(EventArgs e)
        {

            base.OnLoad(e);
            
            this.OnInitializeBinding();
            this.ViewModel.Model.Validated += new EventHandler(Model_Validated);

        }


        public bool IsModelValidate (TModel model)
        {
            //ValidationContext context = new ValidationContext(model, null, null);
            //List<ValidationResult> validationResults = new List<ValidationResult>();
            //return Validator.TryValidateObject(model, context, validationResults, true);
            return !Errors(model).Any();
        }


        protected void Model_Validated(object sender, EventArgs e)
        {
            if (this.ViewModel.Model == null) return;


            this.ViewModel.Model.AttachedControls.ToList().ForEach(c => this.errorProvider.SetError(c.Value as Control, ""));
            var results = new List<ValidationResult>();
            var result = Validator.TryValidateObject(this,
                new ValidationContext(this, null, null), results, true);
            if (!results.Any())
            {
                this.ViewModel.Model.Messages.ToList().ForEach(message =>
                {
                    this.errorProvider.SetError(this.ViewModel.Model.AttachedControls[message.Key] as Control, message.Value);
                });
            }
        }

        public IEnumerable<ValidationResult> Errors(TModel model)
        {
            var results = new List<ValidationResult>();
            var result = Validator.TryValidateObject(this,
                new ValidationContext(model, null, null), results, true);
            return results;

        }

        protected virtual void OnInitializeBinding() { }

    }
}

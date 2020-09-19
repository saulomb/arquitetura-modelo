using ArquiteturaModelo.Apresentacao.WF.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaModelo.Apresentacao.WF.ViewModel.Base
{
    public class ViewModel<TModel> : IViewModel where TModel : BaseModel

    {

        private TModel model;

        public ViewModel(TModel model)
        {
            this.Model = model;
        }

        public TModel Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
                //SetField(ref model, value);
            }    
        }


    }
}

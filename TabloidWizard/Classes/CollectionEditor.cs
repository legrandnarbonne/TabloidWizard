using System;

namespace TabloidWizard.Classes
{
    public class CollectionEditor<T> : System.ComponentModel.Design.CollectionEditor
    {
        public CollectionEditor(Type type)
            : base(type)
        {
        }

        protected override Type CreateCollectionItemType()
        {
            return typeof(T);
        }
    }
}
using System;
using System.Reflection;

namespace BaseClasses
{
    /// <summary>
    /// Classe de base pour tous les classe de mappage de modele
    /// </summary>
    public class BaseViewData : BindableBase
    {
        /// <summary>
        /// Récupère les valeurs de propriétés publiques d'un objet
        /// </summary>
        /// <param name="o">Object contenant les valeurs à récupérer</param>
        public void GetPropertiesValues(object o)
        {
            foreach (PropertyInfo p in o.GetType().GetProperties())
            {
                if (this.GetType().GetProperty(p.Name) != null)
                {
                    this.GetType().GetProperty(p.Name).SetValue(this, p.GetValue(o));
                }               
            }
        }
    }
}

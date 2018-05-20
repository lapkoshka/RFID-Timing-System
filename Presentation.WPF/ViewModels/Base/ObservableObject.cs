using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Presentation.WPF.ViewModels.Base
{
    public class ObservableObject: INotifyPropertyChanged, INotifyPropertyChanging
    {
        [Browsable(false)]
        public bool NotificationSuspended
        {
            get;
            set;
        }

        #region Implementation of INotifyPropertyChanged

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
            }

            protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
            {
                if (NotificationSuspended == false)
                {
                    var handler = PropertyChanged;
                    if (handler != null)
                    {
                        handler(this, args);
                    }
                }
            }

            protected virtual void OnPropertyChanged<TProperty>(Expression<Func<TProperty>> property)
            {
                var lambda = (LambdaExpression)property;
                MemberExpression memberExpression;

                if (lambda.Body is UnaryExpression)
                {
                    var unaryExpression = (UnaryExpression)lambda.Body;
                    memberExpression = (MemberExpression)unaryExpression.Operand;
                }
                else
                {
                    memberExpression = (MemberExpression)lambda.Body;
                }

                OnPropertyChanged(memberExpression.Member.Name);
            }

            #endregion

        #region Implementation of INotifyPropertyChanging

            public event PropertyChangingEventHandler PropertyChanging;

            protected virtual void OnPropertyChanging(string propertyName)
            {
                OnPropertyChanging(new PropertyChangingEventArgs(propertyName));
            }

            protected virtual void OnPropertyChanging(PropertyChangingEventArgs args)
            {
                if (NotificationSuspended == false)
                {
                    var handler = PropertyChanging;
                    if (handler != null)
                    {
                        handler(this, args);
                    }
                }
            }

            protected virtual void OnPropertyChanging<TProperty>(Expression<Func<TProperty>> property)
            {
                var lambda = (LambdaExpression)property;
                MemberExpression memberExpression;

                if (lambda.Body is UnaryExpression)
                {
                    var unaryExpression = (UnaryExpression)lambda.Body;
                    memberExpression = (MemberExpression)unaryExpression.Operand;
                }
                else
                {
                    memberExpression = (MemberExpression)lambda.Body;
                }

                OnPropertyChanging(memberExpression.Member.Name);
            }

            #endregion
    }
}

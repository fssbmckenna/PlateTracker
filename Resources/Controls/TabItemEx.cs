﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;


namespace PlateTracker.Resources.Controls
{
    public class TabItemEx : TabItem
    {

        public static readonly DependencyProperty TabHeaderTextProperty =
            DependencyProperty.Register("TabHeaderText", typeof (string), typeof (TabItemEx), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty TabImageProperty =
            DependencyProperty.Register("TabImage", typeof (string), typeof (TabItemEx),
                new PropertyMetadata(string.Empty));

        public string TabHeaderText
        {
            get { return (string) GetValue(TabImageProperty); }
            set { SetValue(TabHeaderTextProperty, value);}
        }

        public string TabImage
        {
            get { return (string) GetValue(TabImageProperty); }
            set { SetValue(TabImageProperty, value);}
        }
    }
}

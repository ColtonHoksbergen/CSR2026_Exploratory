using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using System;

namespace CSR2026_Exploratory;

public partial class CustomTimePicker : UserControl
{
    int hoursCount = 0;
    int minutesCount = 0;

    bool hoursHasFocus = false;
    bool minutesHasFocus = false;
    bool ampmHasFocus = false;

    public static readonly StyledProperty<TimeSpan?> TimeSpanProperty =
        AvaloniaProperty.Register<CustomTimePicker, TimeSpan?>(nameof(TimeSpan));

    public TimeSpan? timeSpan;

    public TimeSpan? TimeSpan
    {
        get { return GetValue(TimeSpanProperty); }
        set { SetValue(TimeSpanProperty, value); }
    }

    public CustomTimePicker()
    {
        InitializeComponent();
        btnUp.Click += BtnUp_Click;
        btnDown.Click += BtnDown_Click;

        txtHours.GotFocus += TxtHours_GotFocus;
        txtMinutes.GotFocus += TxtMinutes_GotFocus;
        txtAMPM.GotFocus += TxtAMPM_GotFocus;

        txtHours.LostFocus += TxtHours_LostFocus;
        txtMinutes.LostFocus += TxtMinutes_LostFocus;
        txtAMPM.LostFocus += TxtAMPM_LostFocus;

        txtHours.KeyDown += TxtHours_KeyDown;
        txtMinutes.KeyDown += TxtMinutes_KeyDown;

        TimeSpan = new TimeSpan(0, 0, 0);
    }

    private void TxtMinutes_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Up)
        {
            BtnUp_Click(sender, e);
        }

        if (e.Key == Key.Down)
        {
            BtnDown_Click(sender, e);
        }

        if (!string.IsNullOrEmpty(txtMinutes.Text) && txtMinutes.Text.Length > 2)
        {
            txtMinutes.Text = "59";
            minutesCount = 59;
        }

        // if not a number key, ignore
        if (e.Key < Key.D0 || e.Key > Key.D9)
        {
            e.Handled = true;
        }
        else if (!string.IsNullOrEmpty(txtMinutes.Text))
        {
            // set the minutes count
            minutesCount = int.Parse(txtMinutes.Text);
        }
    }

    private void TxtHours_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Up)
        {
            BtnUp_Click(sender, e);
        }

        if (e.Key == Key.Down)
        {
            BtnDown_Click(sender, e);
        }

        // if not a number key, ignore
        if (e.Key < Key.D0 || e.Key > Key.D9)
        {
            e.Handled = true;
        }
    }

    private void TxtAMPM_LostFocus(object? sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(txtAMPM.Text))
        {
            txtAMPM.Text = "AM";
        }

        if (txtAMPM.Text != "AM" && txtAMPM.Text != "PM")
        {
            if (txtAMPM.Text.ToUpper().Contains("P"))
            {
                txtAMPM.Text = "PM";
            }
            else
            {
                txtAMPM.Text = "AM";
            }
        }

        UpdateTimeSpan();
    }

    private void TxtMinutes_LostFocus(object? sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(txtMinutes.Text))
        {
            txtMinutes.Text = "MM";
        }
        else
        {
            minutesCount = int.Parse(txtMinutes.Text);

            if (minutesCount > 59)
            {
                txtMinutes.Text = "59";
                minutesCount = 59;
            }
        }

        UpdateTimeSpan();
    }

    private void TxtHours_LostFocus(object? sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(txtHours.Text))
        {
            txtHours.Text = "HH";
        }
        else
        {
            hoursCount = int.Parse(txtHours.Text);

            if (hoursCount > 12)
            {
                txtHours.Text = "12";
                hoursCount = 12;
            }
        }

        UpdateTimeSpan();
    }

    private void TxtAMPM_GotFocus(object? sender, GotFocusEventArgs e)
    {
        hoursHasFocus = false;
        minutesHasFocus = false;
        ampmHasFocus = true;
        txtAMPM.FontWeight = Avalonia.Media.FontWeight.Bold;
        txtHours.FontWeight = Avalonia.Media.FontWeight.Normal;
        txtMinutes.FontWeight = Avalonia.Media.FontWeight.Normal;
    }

    private void TxtMinutes_GotFocus(object? sender, GotFocusEventArgs e)
    {
        hoursHasFocus = false;
        minutesHasFocus = true;
        ampmHasFocus = false;

        if (txtMinutes.Text == "MM")
        {
            txtMinutes.Clear();
        }

        txtHours.FontWeight = Avalonia.Media.FontWeight.Normal;
        txtMinutes.FontWeight = Avalonia.Media.FontWeight.Bold;
        txtAMPM.FontWeight = Avalonia.Media.FontWeight.Normal;
    }

    private void TxtHours_GotFocus(object? sender, GotFocusEventArgs e)
    {
        hoursHasFocus = true;
        minutesHasFocus = false;
        ampmHasFocus = false;
        
        if (txtHours.Text == "HH")
        {
            txtHours.Clear();
        }

        txtHours.FontWeight = Avalonia.Media.FontWeight.Bold;
        txtMinutes.FontWeight = Avalonia.Media.FontWeight.Normal;
        txtAMPM.FontWeight = Avalonia.Media.FontWeight.Normal;
    }

    private void BtnDown_Click(object? sender, RoutedEventArgs e)
    {
        if (hoursHasFocus)
        {
            hoursCount--;
            if (hoursCount == 0)
            {
                hoursCount = 12;
            }

            if (hoursCount < 10)
            {
                txtHours.Text = "0" + hoursCount.ToString(); 
            }
            else
            {
                txtHours.Text = hoursCount.ToString();
            }
        }
        else if (minutesHasFocus)
        {
            minutesCount--;
            if (minutesCount == -1)
            {
                minutesCount = 59;
            }
            if (minutesCount < 10)
            {
                txtMinutes.Text = "0" + minutesCount.ToString();
            }
            else
            {
                txtMinutes.Text = minutesCount.ToString();
            }
        }
        else if (ampmHasFocus)
        {
            ToggleAM_PM();
        }

        UpdateTimeSpan();
    }

    private void BtnUp_Click(object? sender, RoutedEventArgs e)
    {
        if (hoursHasFocus)
        {
            hoursCount++;
            if (hoursCount == 13)
            {
                hoursCount = 1;
            }

            if (hoursCount < 10)
            {
                txtHours.Text = "0" + hoursCount.ToString();
            }
            else
            {
                txtHours.Text = hoursCount.ToString();
            }
        }
        else if (minutesHasFocus)
        {
            minutesCount++;
            if (minutesCount == 60)
            {
                minutesCount = 0;
            }

            if (minutesCount < 10)
            {
                txtMinutes.Text = "0" + minutesCount.ToString();
            }
            else
            {
                txtMinutes.Text = minutesCount.ToString();
            }
        }
        else if (ampmHasFocus)
        {
            ToggleAM_PM();
        }

        UpdateTimeSpan();
    }

    private void ToggleAM_PM()
    {
        if (txtAMPM.Text == "AM")
        {
            txtAMPM.Text = "PM";
        }
        else
        {
            txtAMPM.Text = "AM";
        }
    }

    private void UpdateTimeSpan()
    {
        if (txtAMPM.Text == "PM")
        {
            TimeSpan = new TimeSpan(hoursCount + 12, minutesCount, 0);
        }
        else
        {
            TimeSpan = new TimeSpan(hoursCount, minutesCount, 0);
        }
    }
}
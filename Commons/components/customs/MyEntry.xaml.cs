using CommunityToolkit.Maui.Behaviors;
using MatontineDigitalApp.Commons.behaviors;
using NumericValidationBehavior = MatontineDigitalApp.Commons.behaviors.NumericValidationBehavior;

namespace MatontineDigitalApp.Commons.components.customs
{
  public partial class MyEntry : ContentView
  {
    public event EventHandler MyBtnClicked;
    public event EventHandler<EventArgs> Completed;
    public event EventHandler<TextChangedEventArgs> TextChanged;


    private string currentFormat;

    private NumericValidationBehavior numericValidationBehavior = new NumericValidationBehavior();
    private PhoneNumberBehavior phoneNumberBehavior = new PhoneNumberBehavior();
    private AmountBehavior amountBehavior = new AmountBehavior();


    public MyEntry()
    {
      InitializeComponent();

      text.TextChanged += Text_TextChanged;
      text.Completed += Text_Completed;
      text.Focused += Text_Focused;

      btnText.Clicked += BtnText_Clicked;

    }

    public Entry TextEntry { get => text; }

    private void Text_Focused(object sender, FocusEventArgs e)
    {
      InitMessageError();
    }

    private void BtnText_Clicked(object sender, EventArgs e)
    {
      MyBtnClicked?.Invoke(sender, e);
    }

    public void InitMessageError(string msg = null)
    {
      Color color = msg == null ? Colors.Gray : Colors.Red;
      Message = (string.IsNullOrEmpty(msg)) ? "" : msg;

      PutMessageColor(color);
    }

    public void PutMessageColor(Color color)
    {
      title.TextColor = color;
      message.TextColor = color;
      text.TextColor = color;
      frame.BorderColor = color;

    }

    private void handleKeyboard(bool _use, Keyboard kb)
    {
      if (_use)
      {
        text.Keyboard = kb;
      }
      else
      {
        text.Keyboard = Keyboard.Default;
      }
    }

    private void handleBehavior(bool _use, Behavior be)
    {
      var res = text.Behaviors.Remove(be);
      while (res)
      {
        res = text.Behaviors.Remove(be);
      }

      if (_use)
      {
        text.Behaviors.Add(be);
      }
    }


    public string NumericBehaviorFormat
    {
      set
      {
        currentFormat = value;
        var _use = !string.IsNullOrEmpty(value);
        numericValidationBehavior.Format = value;
        handleBehavior(_use, numericValidationBehavior);
        handleKeyboard(_use, Keyboard.Numeric);
      }
    }


    public string PhoneNumberBehaviorFormat
    {
      set
      {
        currentFormat = value;
        var _use = !string.IsNullOrEmpty(value);
        phoneNumberBehavior.Format = value;
        handleBehavior(_use, phoneNumberBehavior);
        handleKeyboard(_use, Keyboard.Telephone);
      }
    }



    public string AmountBehaviorFormat
    {
      set
      {
        currentFormat = value;
        var _use = !string.IsNullOrEmpty(value);
        amountBehavior.Format = value;
        handleBehavior(_use, amountBehavior);
        handleKeyboard(_use, Keyboard.Numeric);
      }
    }

    private bool _CenterContent;

    public bool CenterContent
    {
      get => _CenterContent;
      set
      {
        _CenterContent = value;
        if (_CenterContent)
        {
          text.Margin = new Thickness(0);
          text.HorizontalTextAlignment = TextAlignment.Center;
        }
      }
    }

    public bool IsPassword
    {
      get => text.IsPassword;
      set => text.IsPassword = value;
    }

    public ReturnType ReturnType
    {
      get => text.ReturnType;
      set => text.ReturnType = value;
    }

    public bool IsReadOnly
    {
      get => text.IsReadOnly;
      set
      {
        text.IsReadOnly = value;
        if (text.IsReadOnly)
        {
          text.TextColor = CommonsResources.primaryColor;
        }
      }
    }

    public bool IsBtnMode
    {
      get => btnText.IsVisible;
      set
      {
        btnText.IsVisible = value;
        text.IsVisible = !value;
      }
    }

    public int MaxLength
    {
      get => text.MaxLength;
      set => text.MaxLength = value;
    }

    public string Placeholder
    {
      get => text.Placeholder;
      set => text.Placeholder = value;
    }

    public Keyboard Keyboard
    {
      get => text.Keyboard;
      set => text.Keyboard = value;
    }

    private void Text_TextChanged(object sender, TextChangedEventArgs e)
    {
      Text = e.NewTextValue;
      TextChanged?.Invoke(sender, e);
    }

    private void Text_Completed(object sender, EventArgs e)
    {
      Completed?.Invoke(sender, e);
    }

    public static readonly BindableProperty TitleProperty = BindableProperty
        .Create(nameof(Title), typeof(string), typeof(MyEntry), default(string), BindingMode.OneWay);
    public string Title
    {
      get
      {
        return (string)GetValue(TitleProperty);
      }

      set
      {
        SetValue(TitleProperty, value);
      }
    }

    public static readonly BindableProperty MessageProperty = BindableProperty
        .Create(nameof(Message), typeof(string), typeof(MyEntry), default(string), BindingMode.OneWay);
    public string Message
    {
      get
      {
        return (string)GetValue(MessageProperty);
      }

      set
      {
        SetValue(MessageProperty, value);
      }
    }

    public static readonly BindableProperty TextProperty = BindableProperty
        .Create(nameof(Text), typeof(string), typeof(MyEntry), default(string), BindingMode.TwoWay);
    public string Text
    {
      get
      {
        return (string)GetValue(TextProperty);
      }

      set
      {
        SetValue(TextProperty, value);
      }
    }

    protected override void OnPropertyChanged(string propertyName = null)
    {
      base.OnPropertyChanged(propertyName);

      if (propertyName == TitleProperty.PropertyName)
      {
        title.Text = Title;
        title.IsVisible = !string.IsNullOrEmpty(title.Text);
      }
      else if (propertyName == MessageProperty.PropertyName)
      {
        message.Text = Message;
        message.IsVisible = !string.IsNullOrEmpty(message.Text);
      }
      else if (propertyName == TextProperty.PropertyName)
      {
        text.Text = Text;
        btnText.Text = Text;
      }


    }


    public string GetClearText()
    {
      return Utils.ClearFormatText(Text, currentFormat);
    }

  }
}
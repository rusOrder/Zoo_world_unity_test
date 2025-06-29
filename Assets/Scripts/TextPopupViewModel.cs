using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPopupViewModel : ITextPopupViewModel
{
    private readonly TextPopupView _view;

    public TextPopupViewModel(TextPopupView view)
    {
        _view = view;
    }

    public void ShowPopup(string text, Vector3 position)
    {
        _view.Show(text, position);
    }
}

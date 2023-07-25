from .models import PlayersAccount
from django.forms import ModelForm, TextInput


class PlayersAccountForm(ModelForm):
    class Meta:
        model = PlayersAccount
        fields = ['id_account', 'email','login','password','player_id']

        widgets = {
            "id_account": TextInput(attrs={
                'class': 'form-control',
                'placeholder': "ID account"
            }),
            "email": TextInput(attrs={
                'class': 'form-control',
                'placeholder': "Email"
            }),
            "login": TextInput(attrs={
                'class': 'form-control',
                'placeholder': "Login"
            }),
            "password": TextInput(attrs={
                'class': 'form-control',
                'placeholder': "Password"
            }),
            "player_id": TextInput(attrs={
                'class': 'form-control',
                'placeholder': "Player ID"
            })
        }
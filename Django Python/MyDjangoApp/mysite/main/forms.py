from .models import PlayersAccount, PlayerInfo, PlayerPurchases
from django.forms import ModelForm, TextInput


class AccountForm(ModelForm):
    class Meta:
        model = PlayersAccount
        fields = ['id_account', 'email', 'login', 'password', 'player_id']

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


class InfoForm(ModelForm):
    class Meta:
        model = PlayerInfo
        fields = ['id_player', 'name', 'surname', 'nickname']

        widgets = {
            "id_player": TextInput(attrs={
                'class': 'form-control',
                'placeholder': "ID player"
            }),
            "name": TextInput(attrs={
                'class': 'form-control',
                'placeholder': "Name"
            }),
            "surname": TextInput(attrs={
                'class': 'form-control',
                'placeholder': "Surname"
            }),
            "nickname": TextInput(attrs={
                'class': 'form-control',
                'placeholder': "Nickname"
            })
        }


class PurchasesForm(ModelForm):
    class Meta:
        model = PlayerPurchases
        fields = ['id_purchas', 'account_id', 'amount']

        widgets = {
            "id_purchas": TextInput(attrs={
                'class': 'form-control',
                'placeholder': "ID purchas"
            }),
            "account_id": TextInput(attrs={
                'class': 'form-control',
                'placeholder': "ID account"
            }),
            "amount": TextInput(attrs={
                'class': 'form-control',
                'placeholder': "Amount"
            })
        }
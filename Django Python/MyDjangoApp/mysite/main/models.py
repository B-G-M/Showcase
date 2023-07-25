from django.db import models


# Create your models here.
class PlayersAccount(models.Model):
    id_account = models.IntegerField()
    email = models.CharField(max_length=20)
    login = models.CharField(max_length=20)
    password = models.CharField(max_length=50)
    player_id = models.IntegerField()

    def __str__(self):
        return self.login

    def get_absolute_url(self):
        return '/'


class PlayerInfo(models.Model):
    id_player = models.IntegerField()
    name = models.CharField(max_length=15)
    surname = models.CharField(max_length=20)
    nickname = models.CharField(max_length=20)

    def __str__(self):
        return self.nickname

    def get_absolute_url(self):
        return '/'


class PlayerPurchases(models.Model):
    id_purchas = models.IntegerField()
    account_id = models.IntegerField()
    amount = models.IntegerField()

    #def __str__(self):
       # return self.account_id

    def get_absolute_url(self):
        return '/'
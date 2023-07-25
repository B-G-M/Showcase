from django.db import models


# Create your models here.
class PlayersAccount(models.Model):
    id_account = models.IntegerField()
    email = models.CharField(max_length=20)
    login = models.CharField(max_length=20)
    password = models.CharField(max_length=50)
    player_id = models.IntegerField()

    def __str__(self):
        return self.id_account

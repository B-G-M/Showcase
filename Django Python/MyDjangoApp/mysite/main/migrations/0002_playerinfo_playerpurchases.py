# Generated by Django 4.0 on 2021-12-28 19:08

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('main', '0001_initial'),
    ]

    operations = [
        migrations.CreateModel(
            name='PlayerInfo',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('id_player', models.IntegerField()),
                ('name', models.CharField(max_length=15)),
                ('surname', models.CharField(max_length=20)),
                ('nickname', models.CharField(max_length=20)),
            ],
        ),
        migrations.CreateModel(
            name='PlayerPurchases',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('id_purchas', models.IntegerField()),
                ('account_id', models.IntegerField()),
                ('amount', models.IntegerField()),
            ],
        ),
    ]
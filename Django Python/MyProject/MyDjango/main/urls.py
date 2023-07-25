from django.urls import path, include
from . import views

urlpatterns = [
    path('', views.index, name='home'),
    path('add_player', views.add_player, name='add_player')
]

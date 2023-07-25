from django.shortcuts import render, redirect
from .models import PlayersAccount
from .forms import PlayersAccountForm
from django.views.generic import DetailView

# Create your views here.


def index(request):
    player = PlayersAccount.objects.all()
    return render(request, 'main/index.html', {'player': player})


def add_player(request):
    error = ''
    if request.method == 'POST':
        form = PlayersAccountForm(request.POST)
        if form.is_valid():
            form.save()
            return redirect('home')
        else:
            error = 'Некорректный ввод'

    form = PlayersAccountForm

    data = {
        'form': form
    }
    return render(request, 'main/add_player.html', data)

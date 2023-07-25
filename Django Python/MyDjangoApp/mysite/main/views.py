from django.shortcuts import render, redirect
from .models import PlayersAccount, PlayerInfo, PlayerPurchases
from .forms import AccountForm, InfoForm, PurchasesForm
from django.views.generic import UpdateView, DeleteView


# Create your views here.
def main(request):
    account = PlayersAccount.objects.all()
    info = PlayerInfo.objects.all()
    purchases = PlayerPurchases.objects.all()
    return render(request, 'main/main.html', {'account': account, 'info': info, 'purchases': purchases})


class DbUpdateView(UpdateView):
    model = PlayersAccount
    template_name = 'main/create.html'

    form_class = AccountForm


class DbUpdateView1(UpdateView):
    model = PlayerInfo
    template_name = 'main/create1.html'

    form_class = InfoForm


class DbUpdateView2(UpdateView):
    model = PlayerPurchases
    template_name = 'main/create2.html'

    form_class = PurchasesForm


class DbDeleteView(DeleteView):
    model = PlayersAccount
    success_url = '/'
    template_name = 'main/delete.html'


class DbDeleteView1(DeleteView):
    model = PlayerInfo
    success_url = '/'
    template_name = 'main/delete1.html'


class DbDeleteView2(DeleteView):
    model = PlayerPurchases
    success_url = '/'
    template_name = 'main/delete2.html'


def create(request):
    error = ''
    if request.method == 'POST':
        form = AccountForm(request.POST)
        if form.is_valid():
            form.save()
            return redirect('main')
        else:
            error = 'Ошибка ввода.'

    form = AccountForm()

    data = {
        'form': form,
        'error': error
    }
    return render(request, 'main/create.html', data)


def create1(request):
    error = ''
    if request.method == 'POST':
        form = InfoForm(request.POST)
        if form.is_valid():
            form.save()
            return redirect('main')
        else:
            error = 'Ошибка ввода.'

    form = InfoForm()

    data = {
        'form': form,
        'error': error
    }
    return render(request, 'main/create1.html', data)


def create2(request):
    error = ''
    if request.method == 'POST':
        form = PurchasesForm(request.POST)
        if form.is_valid():
            form.save()
            return redirect('main')
        else:
            error = 'Ошибка ввода.'

    form = PurchasesForm()

    data = {
        'form': form,
        'error': error
    }
    return render(request, 'main/create2.html', data)



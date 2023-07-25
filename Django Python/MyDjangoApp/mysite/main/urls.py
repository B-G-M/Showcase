from django.urls import path
from . import views

urlpatterns = [
    path('', views.main, name='main'),
    path('create/', views.create, name='create'),
    path('create1/', views.create1, name='create1'),
    path('create2/', views.create2, name='create2'),
    path('<int:pk>/update/', views.DbUpdateView.as_view(), name='update'),
    path('<int:pk>/update1/', views.DbUpdateView1.as_view(), name='update1'),
    path('<int:pk>/update2/', views.DbUpdateView2.as_view(), name='update2'),
    path('<int:pk>/delete/', views.DbDeleteView.as_view(), name='delete'),
    path('<int:pk>/delete1/', views.DbDeleteView1.as_view(), name='delete1'),
    path('<int:pk>/delete2/', views.DbDeleteView2.as_view(), name='delete2')

]
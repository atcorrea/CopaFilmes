import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http'

import { AppComponent } from './app.component';
import { ListaFilmesComponent } from './lista-filmes/lista-filmes.component';
import { ResultadoComponent } from './resultado/resultado.component';
import { HeaderComponent } from './header/header.component';
import { AppRoutingModule } from './app-routing.module';
import { CopaService } from './_services/copa.service';

@NgModule({
   declarations: [
      AppComponent,
      ListaFilmesComponent,
      ResultadoComponent,
      HeaderComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      AppRoutingModule
   ],
   providers: [
      CopaService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }

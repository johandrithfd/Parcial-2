import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';
import { InicioComponent } from './inicio/inicio.component';
import { EncabezadoComponent } from './encabezado/encabezado.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { AppRoutingModule } from './app-routing.module';
import { FooterComponent } from './footer/footer.component';
import { AlertModalComponent } from './@base/alert-modal/alert-modal.component';
import { RegistroEmpresaComponent } from './Segundo Parcial/Componentes/registro-empresa/registro-empresa.component';
import { ConsultaEmpresaComponent } from './Segundo Parcial/Componentes/consulta-empresa/consulta-empresa.component';
import { ConsultaAbonosComponent } from './Segundo Parcial/Componentes/consulta-empresa/consulta-abonos/consulta-abonos.component';

@NgModule({
  declarations: [
    AppComponent,
    InicioComponent,
    EncabezadoComponent,
    NavMenuComponent,
    FooterComponent,
    AlertModalComponent,
    RegistroEmpresaComponent,
    ConsultaEmpresaComponent,
    ConsultaAbonosComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    NgbModule
  ],
  entryComponents: [AlertModalComponent],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

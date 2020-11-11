import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InicioComponent } from './inicio/inicio.component';
import { ConsultaEmpresaComponent } from './Segundo Parcial/Componentes/consulta-empresa/consulta-empresa.component';
import { RegistroEmpresaComponent } from './Segundo Parcial/Componentes/registro-empresa/registro-empresa.component';

const routes: Routes = [
  {path: '', component: InicioComponent},
  {path: 'consulta-empresa', component: ConsultaEmpresaComponent},
  {path: 'registro-empresa', component: RegistroEmpresaComponent}
];

@NgModule({
declarations: [],
imports: [
  RouterModule.forRoot(routes)
],
exports: [RouterModule]
})
export class AppRoutingModule { }

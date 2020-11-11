import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InicioComponent } from './inicio/inicio.component';
import { ConsultaEmpresaComponent } from './Segundo Parcial/Componentes/consulta-empresa/consulta-empresa.component';

const routes: Routes = [
  {path: '', component: InicioComponent},
  {path: 'consulta-empresa', component: ConsultaEmpresaComponent},
];

@NgModule({
declarations: [],
imports: [
  RouterModule.forRoot(routes)
],
exports: [RouterModule]
})
export class AppRoutingModule { }

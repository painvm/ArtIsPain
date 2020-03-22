import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { appRoutes } from './routes';
import { BandService } from './_services/band.service';
import { BandResolver } from './_resolvers/band.resolver';
import { BandViewComponent } from './bands/band-view/band.component';
import { BandsComponent } from './bands/band-list/BandsComponent';
import { BandEditComponent } from './bands/band-edit/band-edit.component';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { BandEditResolver } from './_resolvers/band-edit-resolver';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import {MatInputModule} from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    BandViewComponent,
    BandsComponent,
    BandEditComponent
  ],
  imports: [
    BrowserModule,
    BsDatepickerModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(appRoutes),
    MatDatepickerModule,
    MatNativeDateModule,
    BrowserAnimationsModule,
    MatInputModule,
    MatMenuModule,
    MatIconModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    BsDatepickerModule.forRoot()
  ],
  providers: [
    BandService,
    BandResolver,
    BandEditResolver,
    MatDatepickerModule,
    MatFormFieldModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}

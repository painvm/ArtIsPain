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
import { AlbumViewResolver } from './_resolvers/album-view-resolver';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import {MatInputModule} from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AlbumViewComponent } from './albums/album-view/album-view.component';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [
    AppComponent,
    AlbumViewComponent,
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
    MatButtonModule,
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
    AlbumViewResolver,
    MatDatepickerModule,
    MatFormFieldModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}

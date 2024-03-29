import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { appRoutes } from './routes';
import { BandService } from './_services/band.service';
import { BandViewResolver } from './_resolvers/band-view-resolver';
import { BandViewComponent } from './bands/band-view/band.component';
import { BandsComponent } from './bands/band-list/BandsComponent';
import { BandEditComponent } from './bands/band-edit/band-edit.component';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { BandEditResolver } from './_resolvers/band-edit-resolver';
import { AlbumViewResolver } from './_resolvers/album-view-resolver';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AlbumViewComponent } from './albums/album-view/album-view.component';
import { MatButtonModule } from '@angular/material/button';
import { AlbumEditComponent } from './albums/album-edit/album-edit/album-edit.component';
import { AlbumEditResolver } from './_resolvers/album-edit-resolver';
import { SongPreviewCardComponent } from './songs/song-preview-card/song-preview-card.component';
import { MatCardModule } from '@angular/material/card';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { NgxsModule } from '@ngxs/store';
import { environment } from 'src/environments/environment';
import { BandViewState } from './_state/states/band-view-state';
import { BandEditState } from './_state/states/band-edit-state';
import { NgxsFormPluginModule } from '@ngxs/form-plugin';
import { NgxsStoragePluginModule } from '@ngxs/storage-plugin';
import { NgxsLoggerPluginModule } from '@ngxs/logger-plugin';
import { NgxsRouterPluginModule } from '@ngxs/router-plugin';
import { AlbumViewState } from './_state/states/album-view-state';
import { AlbumEditState } from './_state/states/album-edit-state';
import {MatDividerModule} from '@angular/material/divider';
import {MatListModule} from '@angular/material/list';

// Noop handler for factory function
export function noop() {
  return function () { };
}

@NgModule({
  declarations: [
    AppComponent,
    AlbumViewComponent,
    BandViewComponent,
    BandsComponent,
    BandEditComponent,
    AlbumEditComponent,
    SongPreviewCardComponent,
  ],
  imports: [
    BrowserModule,
    DragDropModule,
    BsDatepickerModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(appRoutes),
    NgxsModule.forRoot([BandViewState, BandEditState, AlbumViewState, AlbumEditState], {
      developmentMode: !environment.production
    }),
    NgxsFormPluginModule.forRoot(),
    MatDatepickerModule,
    MatNativeDateModule,
    MatButtonModule,
    BrowserAnimationsModule,
    MatInputModule,
    MatMenuModule,
    NgxsLoggerPluginModule.forRoot(),
    MatIconModule,
    MatCardModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    MatDividerModule,
    MatListModule,
    BsDatepickerModule.forRoot(),
    NgxsStoragePluginModule.forRoot(
      {key: ["bandEdit", "albumEdit"]}),
      NgxsRouterPluginModule.forRoot(),
    ],
  providers: [
    BandService,
    BandViewResolver,
    BandEditResolver,
    AlbumViewResolver,
    AlbumEditResolver,
    MatDatepickerModule,
    MatFormFieldModule,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

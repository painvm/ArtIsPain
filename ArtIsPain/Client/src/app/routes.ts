import { Routes } from '@angular/router';
import { BandViewResolver } from './_resolvers/band-view-resolver';
import { BandsComponent } from './bands/band-list/BandsComponent';
import { BandViewComponent } from './bands/band-view/band.component';
import { BandEditComponent } from './bands/band-edit/band-edit.component';
import { BandEditResolver } from './_resolvers/band-edit-resolver';
import { AlbumViewResolver } from './_resolvers/album-view-resolver';
import { AlbumViewComponent } from './albums/album-view/album-view.component';
import { AlbumEditResolver } from './_resolvers/album-edit-resolver';
import { AlbumEditComponent } from './albums/album-edit/album-edit/album-edit.component';

export const appRoutes: Routes = [
    {path: 'bands/view/:id', component: BandViewComponent, resolve: {band: BandViewResolver}},
    {path: 'bands/edit/:id', component: BandEditComponent, resolve: {band: BandEditResolver}},
    {path: 'bands/create', component: BandEditComponent, resolve: {band: BandEditResolver}},
    {path: 'albums/view/:id', component: AlbumViewComponent, resolve: {album: AlbumViewResolver}},
    {path: 'albums/edit/:id', component: AlbumEditComponent, resolve: {album: AlbumEditResolver}},
    {path: 'albums/create', component: AlbumEditComponent, resolve: {album: AlbumEditResolver}}
];

import { Routes } from '@angular/router';
import { BandResolver } from './_resolvers/band.resolver';
import { BandsComponent } from './bands/band-list/BandsComponent';
import { BandViewComponent } from './bands/band-view/band.component';
import { BandEditComponent } from './bands/band-edit/band-edit.component';
import { BandEditResolver } from './_resolvers/band-edit-resolver';
import { AlbumViewResolver } from './_resolvers/album-view-resolver';
import { AlbumViewComponent } from './albums/album-view/album-view.component';
import { AlbumEditResolver } from './_resolvers/album-edit-resolver';
import { AlbumEditComponent } from './albums/album-edit/album-edit/album-edit.component';

export const appRoutes: Routes = [
    {path: 'bands/:id', component: BandViewComponent, resolve: {band: BandResolver}, pathMatch: 'full'},
    {path: 'bands/:id/edit', component: BandEditComponent, resolve: {band: BandEditResolver}},
    {path: 'bands', component: BandsComponent},
    {path: 'albums/:id', component: AlbumViewComponent, resolve: {album: AlbumViewResolver}, pathMatch: 'full'},
    {path: 'albums/:id/edit', component: AlbumEditComponent, resolve: {album: AlbumEditResolver}},
];

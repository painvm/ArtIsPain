import { Routes } from '@angular/router';
import { BandResolver } from './_resolvers/band.resolver';
import { BandsComponent } from './bands/band-list/BandsComponent';
import { BandViewComponent } from './bands/band-view/band.component';
import { BandEditComponent } from './bands/band-edit/band-edit.component';
import { BandEditResolver } from './_resolvers/band-edit-resolver';
import { AlbumViewResolver } from './_resolvers/album-view-resolver';
import { AlbumViewComponent } from './albums/album-view/album-view.component';

export const appRoutes: Routes = [
    {path: 'bands/:id', component: BandViewComponent, resolve: {band: BandResolver}},
    {path: 'band/edit', component: BandEditComponent, resolve: {band: BandEditResolver}},
    {path: 'bands', component: BandsComponent},
    {path: 'albums/:id', component: AlbumViewComponent, resolve: {album: AlbumViewResolver}}
];

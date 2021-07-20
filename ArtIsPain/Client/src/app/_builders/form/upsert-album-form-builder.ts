import { BaseFormBuilder } from './base-form-builder';
import { FormBuilder, FormGroup, FormArray } from '@angular/forms';
import { Injectable } from '@angular/core';
import { AlbumViewModel } from '../../models/album/AlbumViewModel';
import { Store } from '@ngxs/store';
import { UpdateFormValue } from '@ngxs/form-plugin';


@Injectable({
    providedIn: 'root'
})
export class UpsertAlbumFormBuilder extends BaseFormBuilder {

    constructor(formBuilder: FormBuilder, public store: Store) {
        super(formBuilder);

    }

    public Initialize() {

        const title = this.formBuilder.control(null);
        const description = this.formBuilder.control(null);
        const url = this.formBuilder.control(null);
        const startRecordDate = this.formBuilder.control(null);
        const releaseDate = this.formBuilder.control(null);
        const bandId = this.formBuilder.control(null);
        const songs = this.formBuilder.array([]);

        let form = this.formBuilder.group({
            title: title,
            description: description,
            url: url,
            startRecordDate: startRecordDate,
            releaseDate: releaseDate,
            bandId: bandId,
            songs: songs
        })

        return form;
    }

    public Build(form: FormGroup, album: AlbumViewModel) {

        if (album.Id) {
            form.controls.title.setValue(album.Title);
            form.controls.description.setValue(album.Description);
            form.controls.url.setValue(album.Url);
            form.controls.startRecordDate.setValue(album.StartRecordDate);
            form.controls.releaseDate.setValue(album.ReleaseDate);

            const array = form.controls.songs as FormArray;

            album.Songs.forEach(song => {
                array.push(this.formBuilder.group({
                    songTitle: this.formBuilder.control(song.Title),
                    editMode: this.formBuilder.control(false),
                    order: this.formBuilder.control(song.Order),
                    id: this.formBuilder.control(song.Id)
                }))
            })
        }

        form.controls.bandId.setValue(album.Band.Id);
    }

    public AddSubArrayElement(actualSongs: FormArray) {

        let order = 1;

        if (actualSongs.length != 0) {

            order = actualSongs.value.sort((a, b) => a.order - b.order)[actualSongs.controls.length - 1].order + 1;
        }

        const song = this.formBuilder.group({
            songTitle: this.formBuilder.control(null),
            editMode: this.formBuilder.control(false),
            order: this.formBuilder.control(order),
            id: this.formBuilder.control(null)
        })

        actualSongs.push(song);
        return song;
    }

}

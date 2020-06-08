import { BaseFormBuilder } from './base-form-builder';
import { FormBuilder, FormGroup, FormArray } from '@angular/forms';
import { Injectable } from '@angular/core';
import { AlbumViewModel } from '../../models/album/AlbumViewModel';


@Injectable({
    providedIn: 'root'
})
export class UpsertAlbumFormBuilder extends BaseFormBuilder {

    constructor(formBuilder: FormBuilder) {
        super(formBuilder);

    }

    public Initialize() {

        const title = this.formBuilder.control(null);
        const description = this.formBuilder.control(null);
        const url = this.formBuilder.control(null);
        const startRecordDate = this.formBuilder.control(null);
        const releaseDate = this.formBuilder.control(null);
        const songs = this.formBuilder.array([]);

        let form = this.formBuilder.group({
            title: title,
            description: description,
            url: url,
            startRecordDate: startRecordDate,
            releaseDate: releaseDate,
            songs: songs
        })

        return form;
    }

    public Build(form: FormGroup, album: AlbumViewModel) {
        form.controls.title.setValue(album.Title);
        form.controls.description.setValue(album.Description);
        form.controls.url.setValue(album.Url);
        form.controls.startRecordDate.setValue(album.StartRecordDate);
        form.controls.releaseDate.setValue(album.ReleaseDate);

        const array = form.controls.songs as FormArray;

        album.Songs.forEach(song => {
            array.push(this.formBuilder.group({
                songTitle: this.formBuilder.control(song.Title),
                editMode: this.formBuilder.control(true),
                order: this.formBuilder.control(song.Order)
            }))
        })
}}

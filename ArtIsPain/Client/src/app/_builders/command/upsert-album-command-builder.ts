import { ICommandBuilder } from "../../_interfaces/i-command-builder";
import { FormGroup } from "@angular/forms";
import { UpsertAlbumCommand } from "../../commands/albums/upsert-album-command";
import { Injectable } from "@angular/core";
import { UpsertSongCommand } from "../../commands/albums/upsert-song-command";

@Injectable({
    providedIn: 'root'
})
export class UpsertAlbumCommandBuilder implements ICommandBuilder {

    Build(form: FormGroup, entityId: string) {

        const upsertAlbumCommand = new UpsertAlbumCommand();
        const bandToUpsert = (form as any).model;

        upsertAlbumCommand.EntityId = entityId;
        upsertAlbumCommand.BandId = bandToUpsert.bandId;
        upsertAlbumCommand.Title = bandToUpsert.title;
        upsertAlbumCommand.Url = bandToUpsert.url;
        upsertAlbumCommand.StartRecordDate = bandToUpsert.startRecordDate;
        upsertAlbumCommand.ReleaseDate = bandToUpsert.releaseDate;
        upsertAlbumCommand.Description = bandToUpsert.description;
        upsertAlbumCommand.Songs = new Array<UpsertSongCommand>();

        bandToUpsert.songs.forEach(song => {
            let songToAdd = new UpsertSongCommand();

            songToAdd.AlbumId = entityId;
            songToAdd.Title = song.songTitle;
            songToAdd.Order = song.order;
            songToAdd.EntityId = song.id;
            upsertAlbumCommand.Songs.push(songToAdd);

            if(!song.id){
                songToAdd.IsNewlyAdded = true;
            }
        });
        

        return upsertAlbumCommand;
    }
}

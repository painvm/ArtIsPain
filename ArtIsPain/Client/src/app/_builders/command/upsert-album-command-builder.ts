import { ICommandBuilder } from "../../_interfaces/i-command-builder";
import { FormGroup } from "@angular/forms";
import { UpsertAlbumCommand } from "../../commands/albums/upsert-album-command";
import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class UpsertAlbumCommandBuilder implements ICommandBuilder {

    Build(form: FormGroup, entityId: string) {

        const upsertAlbumCommand = new UpsertAlbumCommand();
        const bandToUpsert = (form as any).model;

        upsertAlbumCommand.EntityId = entityId;
        upsertAlbumCommand.Title = bandToUpsert.title;
        upsertAlbumCommand.Url = bandToUpsert.url;
        upsertAlbumCommand.StartRecordDate = bandToUpsert.startRecordDate;
        upsertAlbumCommand.ReleaseDate = bandToUpsert.releaseDate;
        upsertAlbumCommand.Description = bandToUpsert.description;

        return upsertAlbumCommand;
    }
}

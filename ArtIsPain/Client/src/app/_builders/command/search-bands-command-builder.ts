import { ICommandBuilder } from "../../_interfaces/i-command-builder";
import { FormGroup } from "@angular/forms";
import { UpsertAlbumCommand } from "../../commands/albums/upsert-album-command";
import { Injectable } from "@angular/core";
import { UpsertSongCommand } from "../../commands/albums/upsert-song-command";
import { SearchBandsCommand } from "../../commands/bands/search.bands.command";
import { CompileSummaryKind } from "@angular/compiler";

@Injectable({
    providedIn: 'root'
})
export class SearchBandsCommandBuilder {

    Build(searchTerm?: string) {

        var command = new SearchBandsCommand();
        command.searchTerm = searchTerm;

        return command;
    }
}

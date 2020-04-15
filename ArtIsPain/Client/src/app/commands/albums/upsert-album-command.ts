import { UpsertSongCommand } from "./upsert-song-command";
import { IUpsertEntityCommand } from "src/app/_interfaces/i-upsert-entity-command";

export class UpsertAlbumCommand implements IUpsertEntityCommand {
  EntityId?: string;
  BandId: string;
  Title: string;
  Description: string;
  Url: string;
  StartRecordDate?: Date;
  ReleaseDate: Date;
  Songs: UpsertSongCommand[];
}

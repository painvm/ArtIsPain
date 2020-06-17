import { Time } from "@angular/common";
import { IUpsertEntityCommand } from "../../_interfaces/i-upsert-entity-command";
import { IDynamicallyAdded } from "../../_interfaces/i-dynamically-added";

export class UpsertSongCommand implements IUpsertEntityCommand, IDynamicallyAdded {
  EntityId?: string;
  AlbumId?: string;
  Title: string;
  Order: number;
  Length: Time;
  IsEditMode = false;
  IsNewlyAdded: boolean;
}

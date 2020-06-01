import { FormGroup } from '@angular/forms';
import { Injectable } from '@angular/core';
import { UpsertBandCommand } from '../../commands/bands/upsert.band.command';
import { ICommandBuilder } from '../../_interfaces/i-command-builder';

@Injectable({
    providedIn: 'root'
})

export class UpsertBandCommandBuilder implements ICommandBuilder {
    Build(form: FormGroup, entityId?: string) {

        const upsertBandCommand = new UpsertBandCommand();
        const bandToUpsert = (form as any).model;

        upsertBandCommand.Name = bandToUpsert.title;
        upsertBandCommand.FormationDate = bandToUpsert.formationDate;
        upsertBandCommand.DisbandDate = bandToUpsert.disbandDate;
        upsertBandCommand.Description = bandToUpsert.biography;
        upsertBandCommand.EntityId = entityId;

        return upsertBandCommand;
    }

}

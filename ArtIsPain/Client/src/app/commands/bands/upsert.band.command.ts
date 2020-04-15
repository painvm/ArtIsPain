import { IUpsertEntityCommand } from 'src/app/_interfaces/i-upsert-entity-command';

export class UpsertBandCommand implements IUpsertEntityCommand {
    EntityId: string;
    Name: string;
    Description?: string;
    FormationDate: Date;
    DisbandDate?: Date;
}


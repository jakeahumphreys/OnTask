using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTask.Migrations
{
    public partial class ModelNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Tasks_ProjectTaskTaskId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "ProjectTaskTaskId",
                table: "Activities",
                newName: "TaskRecordTaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Activities_ProjectTaskTaskId",
                table: "Activities",
                newName: "IX_Activities_TaskRecordTaskId");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectRecordProjectId",
                table: "Tasks",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectRecordProjectId",
                table: "Tasks",
                column: "ProjectRecordProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Tasks_TaskRecordTaskId",
                table: "Activities",
                column: "TaskRecordTaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Projects_ProjectRecordProjectId",
                table: "Tasks",
                column: "ProjectRecordProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Tasks_TaskRecordTaskId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projects_ProjectRecordProjectId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ProjectRecordProjectId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ProjectRecordProjectId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "TaskRecordTaskId",
                table: "Activities",
                newName: "ProjectTaskTaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Activities_TaskRecordTaskId",
                table: "Activities",
                newName: "IX_Activities_ProjectTaskTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Tasks_ProjectTaskTaskId",
                table: "Activities",
                column: "ProjectTaskTaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

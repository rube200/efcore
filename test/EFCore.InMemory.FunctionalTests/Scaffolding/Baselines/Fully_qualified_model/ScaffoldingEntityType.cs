// <auto-generated />
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Json;

#pragma warning disable 219, 612, 618
#nullable disable

namespace Scaffolding
{
    [EntityFrameworkInternal]
    public partial class ScaffoldingEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "Microsoft.EntityFrameworkCore.Scaffolding.CompiledModelInMemoryTest+Scaffolding",
                typeof(CompiledModelInMemoryTest.Scaffolding),
                baseEntityType,
                propertyCount: 1,
                keyCount: 1);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(long),
                propertyInfo: typeof(CompiledModelInMemoryTest.Scaffolding).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(CompiledModelInMemoryTest.Scaffolding).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueGenerated: ValueGenerated.OnAdd,
                afterSaveBehavior: PropertySaveBehavior.Throw,
                sentinel: 0L);
            id.SetGetter(
                (CompiledModelInMemoryTest.Scaffolding entity) => UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_Scaffolding_Id(entity),
                (CompiledModelInMemoryTest.Scaffolding entity) => UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_Scaffolding_Id(entity) == 0L,
                (CompiledModelInMemoryTest.Scaffolding instance) => UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_Scaffolding_Id(instance),
                (CompiledModelInMemoryTest.Scaffolding instance) => UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_Scaffolding_Id(instance) == 0L);
            id.SetSetter(
                (CompiledModelInMemoryTest.Scaffolding entity, long value) => UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_Scaffolding_Id(entity) = value);
            id.SetMaterializationSetter(
                (CompiledModelInMemoryTest.Scaffolding entity, long value) => UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_Scaffolding_Id(entity) = value);
            id.SetAccessors(
                (InternalEntityEntry entry) => entry.FlaggedAsStoreGenerated(0) ? entry.ReadStoreGeneratedValue<long>(0) : entry.FlaggedAsTemporary(0) && UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_Scaffolding_Id((CompiledModelInMemoryTest.Scaffolding)entry.Entity) == 0L ? entry.ReadTemporaryValue<long>(0) : UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_Scaffolding_Id((CompiledModelInMemoryTest.Scaffolding)entry.Entity),
                (InternalEntityEntry entry) => UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_Scaffolding_Id((CompiledModelInMemoryTest.Scaffolding)entry.Entity),
                (InternalEntityEntry entry) => entry.ReadOriginalValue<long>(id, 0),
                (InternalEntityEntry entry) => entry.ReadRelationshipSnapshotValue<long>(id, 0),
                (ValueBuffer valueBuffer) => valueBuffer[0]);
            id.SetPropertyIndexes(
                index: 0,
                originalValueIndex: 0,
                shadowIndex: -1,
                relationshipIndex: 0,
                storeGenerationIndex: 0);
            id.TypeMapping = InMemoryTypeMapping.Default.Clone(
                comparer: new ValueComparer<long>(
                    (long v1, long v2) => v1 == v2,
                    (long v) => v.GetHashCode(),
                    (long v) => v),
                keyComparer: new ValueComparer<long>(
                    (long v1, long v2) => v1 == v2,
                    (long v) => v.GetHashCode(),
                    (long v) => v),
                providerValueComparer: new ValueComparer<long>(
                    (long v1, long v2) => v1 == v2,
                    (long v) => v.GetHashCode(),
                    (long v) => v),
                clrType: typeof(long),
                jsonValueReaderWriter: JsonInt64ReaderWriter.Instance);
            id.SetCurrentValueComparer(new EntryCurrentValueComparer<long>(id));
            id.AddRuntimeAnnotation("UnsafeAccessors", new[] { ("ScaffoldingEntityType.UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_Scaffolding_Id", "Scaffolding") });

            var key = runtimeEntityType.AddKey(
                new[] { id });
            runtimeEntityType.SetPrimaryKey(key);

            return runtimeEntityType;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            var id = runtimeEntityType.FindProperty("Id")!;
            runtimeEntityType.SetOriginalValuesFactory(
                (InternalEntityEntry source) =>
                {
                    var entity = (CompiledModelInMemoryTest.Scaffolding)source.Entity;
                    return (ISnapshot)new Snapshot<long>(((ValueComparer<long>)id.GetValueComparer()).Snapshot(source.GetCurrentValue<long>(id)));
                });
            runtimeEntityType.SetStoreGeneratedValuesFactory(
                () => (ISnapshot)new Snapshot<long>(((ValueComparer<long>)id.GetValueComparer()).Snapshot(default(long))));
            runtimeEntityType.SetTemporaryValuesFactory(
                (InternalEntityEntry source) => (ISnapshot)new Snapshot<long>(default(long)));
            runtimeEntityType.SetShadowValuesFactory(
                (IDictionary<string, object> source) => Snapshot.Empty);
            runtimeEntityType.SetEmptyShadowValuesFactory(
                () => Snapshot.Empty);
            runtimeEntityType.SetRelationshipSnapshotFactory(
                (InternalEntityEntry source) =>
                {
                    var entity = (CompiledModelInMemoryTest.Scaffolding)source.Entity;
                    return (ISnapshot)new Snapshot<long>(((ValueComparer<long>)id.GetKeyValueComparer()).Snapshot(source.GetCurrentValue<long>(id)));
                });
            runtimeEntityType.Counts = new PropertyCounts(
                propertyCount: 1,
                navigationCount: 0,
                complexPropertyCount: 0,
                originalValueCount: 1,
                shadowCount: 0,
                relationshipCount: 1,
                storeGeneratedCount: 1);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);

        [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "<Id>k__BackingField")]
        public static extern ref long UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_Scaffolding_Id(CompiledModelInMemoryTest.Scaffolding @this);
    }
}
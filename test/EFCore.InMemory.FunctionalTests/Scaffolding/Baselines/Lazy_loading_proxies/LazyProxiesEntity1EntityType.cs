// <auto-generated />
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Proxies.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Json;

#pragma warning disable 219, 612, 618
#nullable disable

namespace TestNamespace
{
    [EntityFrameworkInternal]
    public partial class LazyProxiesEntity1EntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "Microsoft.EntityFrameworkCore.Scaffolding.CompiledModelInMemoryTest+LazyProxiesEntity1",
                typeof(CompiledModelInMemoryTest.LazyProxiesEntity1),
                baseEntityType,
                propertyCount: 2,
                navigationCount: 1,
                servicePropertyCount: 1,
                foreignKeyCount: 1,
                unnamedIndexCount: 1,
                keyCount: 1);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(int),
                propertyInfo: typeof(CompiledModelInMemoryTest.LazyProxiesEntity1).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(CompiledModelInMemoryTest.LazyProxiesEntity1).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueGenerated: ValueGenerated.OnAdd,
                afterSaveBehavior: PropertySaveBehavior.Throw,
                sentinel: 0);
            id.SetGetter(
                (CompiledModelInMemoryTest.LazyProxiesEntity1 entity) => UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_LazyProxiesEntity1_Id(entity),
                (CompiledModelInMemoryTest.LazyProxiesEntity1 entity) => UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_LazyProxiesEntity1_Id(entity) == 0,
                (CompiledModelInMemoryTest.LazyProxiesEntity1 instance) => UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_LazyProxiesEntity1_Id(instance),
                (CompiledModelInMemoryTest.LazyProxiesEntity1 instance) => UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_LazyProxiesEntity1_Id(instance) == 0);
            id.SetSetter(
                (CompiledModelInMemoryTest.LazyProxiesEntity1 entity, int value) => UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_LazyProxiesEntity1_Id(entity) = value);
            id.SetMaterializationSetter(
                (CompiledModelInMemoryTest.LazyProxiesEntity1 entity, int value) => UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_LazyProxiesEntity1_Id(entity) = value);
            id.SetAccessors(
                (InternalEntityEntry entry) => entry.FlaggedAsStoreGenerated(0) ? entry.ReadStoreGeneratedValue<int>(0) : entry.FlaggedAsTemporary(0) && UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_LazyProxiesEntity1_Id((CompiledModelInMemoryTest.LazyProxiesEntity1)entry.Entity) == 0 ? entry.ReadTemporaryValue<int>(0) : UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_LazyProxiesEntity1_Id((CompiledModelInMemoryTest.LazyProxiesEntity1)entry.Entity),
                (InternalEntityEntry entry) => UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_LazyProxiesEntity1_Id((CompiledModelInMemoryTest.LazyProxiesEntity1)entry.Entity),
                (InternalEntityEntry entry) => entry.ReadOriginalValue<int>(id, 0),
                (InternalEntityEntry entry) => entry.ReadRelationshipSnapshotValue<int>(id, 0),
                (ValueBuffer valueBuffer) => valueBuffer[0]);
            id.SetPropertyIndexes(
                index: 0,
                originalValueIndex: 0,
                shadowIndex: -1,
                relationshipIndex: 0,
                storeGenerationIndex: 0);
            id.TypeMapping = InMemoryTypeMapping.Default.Clone(
                comparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v),
                keyComparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v),
                providerValueComparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v),
                clrType: typeof(int),
                jsonValueReaderWriter: JsonInt32ReaderWriter.Instance);
            id.SetCurrentValueComparer(new EntryCurrentValueComparer<int>(id));
            id.AddRuntimeAnnotation("UnsafeAccessors", new[] { ("LazyProxiesEntity1EntityType.UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_LazyProxiesEntity1_Id", "TestNamespace") });

            var referenceNavigationId = runtimeEntityType.AddProperty(
                "ReferenceNavigationId",
                typeof(int?),
                nullable: true);
            referenceNavigationId.SetPropertyIndexes(
                index: 1,
                originalValueIndex: 1,
                shadowIndex: 0,
                relationshipIndex: 1,
                storeGenerationIndex: 1);
            referenceNavigationId.TypeMapping = InMemoryTypeMapping.Default.Clone(
                comparer: new ValueComparer<int?>(
                    (Nullable<int> v1, Nullable<int> v2) => v1.HasValue && v2.HasValue && (int)v1 == (int)v2 || !v1.HasValue && !v2.HasValue,
                    (Nullable<int> v) => v.HasValue ? (int)v : 0,
                    (Nullable<int> v) => v.HasValue ? (Nullable<int>)(int)v : default(Nullable<int>)),
                keyComparer: new ValueComparer<int?>(
                    (Nullable<int> v1, Nullable<int> v2) => v1.HasValue && v2.HasValue && (int)v1 == (int)v2 || !v1.HasValue && !v2.HasValue,
                    (Nullable<int> v) => v.HasValue ? (int)v : 0,
                    (Nullable<int> v) => v.HasValue ? (Nullable<int>)(int)v : default(Nullable<int>)),
                providerValueComparer: new ValueComparer<int?>(
                    (Nullable<int> v1, Nullable<int> v2) => v1.HasValue && v2.HasValue && (int)v1 == (int)v2 || !v1.HasValue && !v2.HasValue,
                    (Nullable<int> v) => v.HasValue ? (int)v : 0,
                    (Nullable<int> v) => v.HasValue ? (Nullable<int>)(int)v : default(Nullable<int>)),
                clrType: typeof(int),
                jsonValueReaderWriter: JsonInt32ReaderWriter.Instance);
            referenceNavigationId.SetCurrentValueComparer(new EntryCurrentValueComparer<int?>(referenceNavigationId));

            var lazyLoader = runtimeEntityType.AddServiceProperty(
                "LazyLoader",
                propertyInfo: typeof(IProxyLazyLoader).GetProperty("LazyLoader", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                serviceType: typeof(ILazyLoader));
            lazyLoader.SetPropertyIndexes(
                index: -1,
                originalValueIndex: -1,
                shadowIndex: -1,
                relationshipIndex: -1,
                storeGenerationIndex: -1);

            var key = runtimeEntityType.AddKey(
                new[] { id });
            runtimeEntityType.SetPrimaryKey(key);

            var index = runtimeEntityType.AddIndex(
                new[] { referenceNavigationId });

            return runtimeEntityType;
        }

        public static RuntimeForeignKey CreateForeignKey1(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("ReferenceNavigationId") },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Id") }),
                principalEntityType);

            var referenceNavigation = declaringEntityType.AddNavigation("ReferenceNavigation",
                runtimeForeignKey,
                onDependent: true,
                typeof(CompiledModelInMemoryTest.LazyProxiesEntity2),
                propertyInfo: typeof(CompiledModelInMemoryTest.LazyProxiesEntity1).GetProperty("ReferenceNavigation", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(CompiledModelInMemoryTest.LazyProxiesEntity1).GetField("<ReferenceNavigation>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                propertyAccessMode: PropertyAccessMode.Field);

            referenceNavigation.SetGetter(
                (CompiledModelInMemoryTest.LazyProxiesEntity1 entity) => LazyProxiesEntity1EntityType.UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_LazyProxiesEntity1_ReferenceNavigation(entity),
                (CompiledModelInMemoryTest.LazyProxiesEntity1 entity) => LazyProxiesEntity1EntityType.UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_LazyProxiesEntity1_ReferenceNavigation(entity) == null,
                (CompiledModelInMemoryTest.LazyProxiesEntity1 instance) => LazyProxiesEntity1EntityType.UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_LazyProxiesEntity1_ReferenceNavigation(instance),
                (CompiledModelInMemoryTest.LazyProxiesEntity1 instance) => LazyProxiesEntity1EntityType.UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_LazyProxiesEntity1_ReferenceNavigation(instance) == null);
            referenceNavigation.SetSetter(
                (CompiledModelInMemoryTest.LazyProxiesEntity1 entity, CompiledModelInMemoryTest.LazyProxiesEntity2 value) => LazyProxiesEntity1EntityType.UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_LazyProxiesEntity1_ReferenceNavigation(entity) = value);
            referenceNavigation.SetMaterializationSetter(
                (CompiledModelInMemoryTest.LazyProxiesEntity1 entity, CompiledModelInMemoryTest.LazyProxiesEntity2 value) => LazyProxiesEntity1EntityType.UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_LazyProxiesEntity1_ReferenceNavigation(entity) = value);
            referenceNavigation.SetAccessors(
                (InternalEntityEntry entry) => LazyProxiesEntity1EntityType.UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_LazyProxiesEntity1_ReferenceNavigation((CompiledModelInMemoryTest.LazyProxiesEntity1)entry.Entity),
                (InternalEntityEntry entry) => LazyProxiesEntity1EntityType.UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_LazyProxiesEntity1_ReferenceNavigation((CompiledModelInMemoryTest.LazyProxiesEntity1)entry.Entity),
                null,
                (InternalEntityEntry entry) => entry.GetCurrentValue<CompiledModelInMemoryTest.LazyProxiesEntity2>(referenceNavigation),
                null);
            referenceNavigation.SetPropertyIndexes(
                index: 0,
                originalValueIndex: -1,
                shadowIndex: -1,
                relationshipIndex: 2,
                storeGenerationIndex: -1);
            var collectionNavigation = principalEntityType.AddNavigation("CollectionNavigation",
                runtimeForeignKey,
                onDependent: false,
                typeof(ICollection<CompiledModelInMemoryTest.LazyProxiesEntity1>),
                propertyInfo: typeof(CompiledModelInMemoryTest.LazyProxiesEntity2).GetProperty("CollectionNavigation", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(CompiledModelInMemoryTest.LazyProxiesEntity2).GetField("<CollectionNavigation>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                propertyAccessMode: PropertyAccessMode.Field);

            collectionNavigation.SetGetter(
                (CompiledModelInMemoryTest.LazyProxiesEntity2 entity) => LazyProxiesEntity2EntityType.UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_LazyProxiesEntity2_CollectionNavigation(entity),
                (CompiledModelInMemoryTest.LazyProxiesEntity2 entity) => LazyProxiesEntity2EntityType.UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_LazyProxiesEntity2_CollectionNavigation(entity) == null,
                (CompiledModelInMemoryTest.LazyProxiesEntity2 instance) => LazyProxiesEntity2EntityType.UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_LazyProxiesEntity2_CollectionNavigation(instance),
                (CompiledModelInMemoryTest.LazyProxiesEntity2 instance) => LazyProxiesEntity2EntityType.UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_LazyProxiesEntity2_CollectionNavigation(instance) == null);
            collectionNavigation.SetSetter(
                (CompiledModelInMemoryTest.LazyProxiesEntity2 entity, ICollection<CompiledModelInMemoryTest.LazyProxiesEntity1> value) => LazyProxiesEntity2EntityType.UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_LazyProxiesEntity2_CollectionNavigation(entity) = value);
            collectionNavigation.SetMaterializationSetter(
                (CompiledModelInMemoryTest.LazyProxiesEntity2 entity, ICollection<CompiledModelInMemoryTest.LazyProxiesEntity1> value) => LazyProxiesEntity2EntityType.UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_LazyProxiesEntity2_CollectionNavigation(entity) = value);
            collectionNavigation.SetAccessors(
                (InternalEntityEntry entry) => LazyProxiesEntity2EntityType.UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_LazyProxiesEntity2_CollectionNavigation((CompiledModelInMemoryTest.LazyProxiesEntity2)entry.Entity),
                (InternalEntityEntry entry) => LazyProxiesEntity2EntityType.UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_LazyProxiesEntity2_CollectionNavigation((CompiledModelInMemoryTest.LazyProxiesEntity2)entry.Entity),
                null,
                (InternalEntityEntry entry) => entry.GetCurrentValue<ICollection<CompiledModelInMemoryTest.LazyProxiesEntity1>>(collectionNavigation),
                null);
            collectionNavigation.SetPropertyIndexes(
                index: 0,
                originalValueIndex: -1,
                shadowIndex: -1,
                relationshipIndex: 1,
                storeGenerationIndex: -1);
            collectionNavigation.SetCollectionAccessor<CompiledModelInMemoryTest.LazyProxiesEntity2, ICollection<CompiledModelInMemoryTest.LazyProxiesEntity1>, CompiledModelInMemoryTest.LazyProxiesEntity1>(
                (CompiledModelInMemoryTest.LazyProxiesEntity2 entity) => LazyProxiesEntity2EntityType.UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_LazyProxiesEntity2_CollectionNavigation(entity),
                (CompiledModelInMemoryTest.LazyProxiesEntity2 entity, ICollection<CompiledModelInMemoryTest.LazyProxiesEntity1> collection) => LazyProxiesEntity2EntityType.UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_LazyProxiesEntity2_CollectionNavigation(entity) = (ICollection<CompiledModelInMemoryTest.LazyProxiesEntity1>)collection,
                (CompiledModelInMemoryTest.LazyProxiesEntity2 entity, ICollection<CompiledModelInMemoryTest.LazyProxiesEntity1> collection) => LazyProxiesEntity2EntityType.UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_LazyProxiesEntity2_CollectionNavigation(entity) = (ICollection<CompiledModelInMemoryTest.LazyProxiesEntity1>)collection,
                (CompiledModelInMemoryTest.LazyProxiesEntity2 entity, Action<CompiledModelInMemoryTest.LazyProxiesEntity2, ICollection<CompiledModelInMemoryTest.LazyProxiesEntity1>> setter) => ClrCollectionAccessorFactory.CreateAndSetHashSet<CompiledModelInMemoryTest.LazyProxiesEntity2, ICollection<CompiledModelInMemoryTest.LazyProxiesEntity1>, CompiledModelInMemoryTest.LazyProxiesEntity1>(entity, setter),
                () => (ICollection<CompiledModelInMemoryTest.LazyProxiesEntity1>)(ICollection<CompiledModelInMemoryTest.LazyProxiesEntity1>)new HashSet<CompiledModelInMemoryTest.LazyProxiesEntity1>(ReferenceEqualityComparer.Instance));
            return runtimeForeignKey;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            var id = runtimeEntityType.FindProperty("Id")!;
            var referenceNavigationId = runtimeEntityType.FindProperty("ReferenceNavigationId")!;
            var referenceNavigation = runtimeEntityType.FindNavigation("ReferenceNavigation")!;
            runtimeEntityType.SetOriginalValuesFactory(
                (InternalEntityEntry source) =>
                {
                    var entity = (CompiledModelInMemoryTest.LazyProxiesEntity1)source.Entity;
                    return (ISnapshot)new Snapshot<int, Nullable<int>>(((ValueComparer<int>)id.GetValueComparer()).Snapshot(source.GetCurrentValue<int>(id)), source.GetCurrentValue<Nullable<int>>(referenceNavigationId) == null ? null : ((ValueComparer<Nullable<int>>)referenceNavigationId.GetValueComparer()).Snapshot(source.GetCurrentValue<Nullable<int>>(referenceNavigationId)));
                });
            runtimeEntityType.SetStoreGeneratedValuesFactory(
                () => (ISnapshot)new Snapshot<int, Nullable<int>>(((ValueComparer<int>)id.GetValueComparer()).Snapshot(default(int)), default(Nullable<int>) == null ? null : ((ValueComparer<Nullable<int>>)referenceNavigationId.GetValueComparer()).Snapshot(default(Nullable<int>))));
            runtimeEntityType.SetTemporaryValuesFactory(
                (InternalEntityEntry source) => (ISnapshot)new Snapshot<int, Nullable<int>>(default(int), default(Nullable<int>)));
            runtimeEntityType.SetShadowValuesFactory(
                (IDictionary<string, object> source) => (ISnapshot)new Snapshot<Nullable<int>>(source.ContainsKey("ReferenceNavigationId") ? (Nullable<int>)source["ReferenceNavigationId"] : null));
            runtimeEntityType.SetEmptyShadowValuesFactory(
                () => (ISnapshot)new Snapshot<Nullable<int>>(default(Nullable<int>)));
            runtimeEntityType.SetRelationshipSnapshotFactory(
                (InternalEntityEntry source) =>
                {
                    var entity = (CompiledModelInMemoryTest.LazyProxiesEntity1)source.Entity;
                    return (ISnapshot)new Snapshot<int, Nullable<int>, object>(((ValueComparer<int>)id.GetKeyValueComparer()).Snapshot(source.GetCurrentValue<int>(id)), source.GetCurrentValue<Nullable<int>>(referenceNavigationId) == null ? null : ((ValueComparer<Nullable<int>>)referenceNavigationId.GetKeyValueComparer()).Snapshot(source.GetCurrentValue<Nullable<int>>(referenceNavigationId)), UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_LazyProxiesEntity1_ReferenceNavigation(entity));
                });
            runtimeEntityType.Counts = new PropertyCounts(
                propertyCount: 2,
                navigationCount: 1,
                complexPropertyCount: 0,
                originalValueCount: 2,
                shadowCount: 1,
                relationshipCount: 3,
                storeGeneratedCount: 2);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);

        [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "<Id>k__BackingField")]
        public static extern ref int UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_LazyProxiesEntity1_Id(CompiledModelInMemoryTest.LazyProxiesEntity1 @this);

        [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "<ReferenceNavigation>k__BackingField")]
        public static extern ref CompiledModelInMemoryTest.LazyProxiesEntity2 UnsafeAccessor_Microsoft_EntityFrameworkCore_Scaffolding_LazyProxiesEntity1_ReferenceNavigation(CompiledModelInMemoryTest.LazyProxiesEntity1 @this);
    }
}